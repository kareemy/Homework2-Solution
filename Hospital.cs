using System;

namespace Homework2
{
    public class Hospital
    {
        public void SeedDatabase()
        {
            using (var db = new AppDbContext())
            {
                //db.Database.EnsureDeleted();
                if (db.Database.EnsureCreated()) // You need to check if the database already exists, so you don't add these entries multiple times
                {
                    List<Patient> patients = new List<Patient>();
                    patients.Add(new Patient {
                        FirstName = "Edna", LastName = "Krabappel", Age = 41, Gender = "F", AdmitDate = DateTime.Parse("5/28/1943"), HadExam = true
                    });
                    patients.Add(new Patient {
                        FirstName = "Grace", LastName = "Bertrand", Age = 24, Gender = "F", AdmitDate = DateTime.Parse("1/15/1939"), HadExam = true
                    });
                    patients.Add(new Patient {
                        FirstName = "Harold", LastName = "Hill", Age = 52, Gender = "M", AdmitDate = DateTime.Parse("7/1/1943"), HadExam = false
                    });
                    patients.Add(new Patient {
                        FirstName = "Herman", LastName = "Dietrich", Age = 47, Gender = "M", AdmitDate = DateTime.Parse("9/12/1936"), HadExam = true
                    });

                    db.AddRange(patients);
                    db.SaveChanges();
                }                
            }
        }

        public void ListPatients()
        {
            using (var db = new AppDbContext())
            {
                db.Patients.Count();
                foreach (Patient p in db.Patients)
                {
                    Console.WriteLine($"({p.PatientId}) {p.FirstName} {p.LastName}, {p.Age}, {p.Gender}, {p.AdmitDate}, {p.HadExam}");
                }
                // .Count() requires using System.Linq
                Console.WriteLine($"Total patients: {db.Patients.Count()}");
            }            
        }

        public void AddPatient()
        {
            // Gather patient information from the user
            Patient p = new Patient();
            Console.Write("Enter patient first name: ");
            p.FirstName = Console.ReadLine()!;
            Console.Write("Last name: ");
            p.LastName = Console.ReadLine()!;
            Console.Write("Age: ");
            p.Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gender: ");
            p.Gender = Console.ReadLine()!;
            Console.Write("Admit date: ");
            p.AdmitDate = DateTime.Parse(Console.ReadLine()!);
            p.HadExam = false;

            using (var db = new AppDbContext())
            {
                db.Add(p); // Add patient to the database
                db.SaveChanges();
            }            
        }

        public void UpdatePatient()
        {
            string? change = "";
            Console.Write("Enter id of patient to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new AppDbContext())
            {
                Patient p = db.Patients.Find(id)!; // Find patient by id. This is the only way to find a patient so far
                // Prompt user for all possible properties, allowing them to keep the original values or change
                Console.Write($"First name [{p.FirstName}] (Leave empty for no change): ");
                change = Console.ReadLine();
                if (change != "") p.FirstName = change!;
                Console.Write($"Last name [{p.LastName}]: ");
                change = Console.ReadLine();
                if (change != "") p.LastName = change!;
                Console.Write($"Age [{p.Age}]: ");
                change = Console.ReadLine();
                if (change != "") p.Age = Convert.ToInt32(change);
                Console.Write($"Gender [{p.Gender}]: ");
                change = Console.ReadLine();
                if (change != "" && change != null) p.Gender = change;
                Console.Write($"Admit Date [{p.AdmitDate}]: ");
                change = Console.ReadLine();
                if (change != "" && change != null) p.AdmitDate = DateTime.Parse(change);
                Console.Write($"Had Exam [{p.HadExam}]: ");
                change = Console.ReadLine();
                change = change!.ToLower();
                if (change == "y" || change == "yes" || change == "true" || change == "t" || change == "1") p.HadExam = true;
                else if (change == "n" || change == "no" || change == "false" || change == "f" || change == "0") p.HadExam = false;
                // Save changes to database
                db.SaveChanges();
            }            
        }

        public void RemovePatient()
        {
            Console.Write("Enter id of patient to discharge: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new AppDbContext())
            {
                Patient p = db.Patients.Find(id)!; // Find patient by id
                db.Remove(p); // Remove patient from database
                db.SaveChanges();
            }            
        }
    }
}