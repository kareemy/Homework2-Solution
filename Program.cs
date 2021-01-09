using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class Program
    {
        // SeedDatabase() answers requirement #9. It creates a list of existing patients and adds that list to the database
        // It uses db.AddRange() to add the list to the database
        static void SeedDatabase()
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
        // ListPatients() answers requirement #5. It uses foreach to loop through all the patients in the database
        // I added db.Patients.Count() to return a count of how many patients are in the database.
        // This requires "using System.Linq" and is optional on homework 2
        static void ListPatients()
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

        // UpdatePatient() answers requirement #6. Allows user to update patient information for a specific patient
        static void UpdatePatient()
        {
            string change = "";
            Console.Write("Enter id of patient to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new AppDbContext())
            {
                Patient p = db.Patients.Find(id); // Find patient by id. This is the only way to find a patient so far
                // Prompt user for all possible properties, allowing them to keep the original values or change
                Console.Write($"First name [{p.FirstName}] (Leave empty for no change): ");
                change = Console.ReadLine();
                if (change != "") p.FirstName = change;
                Console.Write($"Last name [{p.LastName}]: ");
                change = Console.ReadLine();
                if (change != "") p.LastName = change;
                Console.Write($"Age [{p.Age}]: ");
                change = Console.ReadLine();
                if (change != "") p.Age = Convert.ToInt32(change);
                Console.Write($"Gender [{p.Gender}]: ");
                change = Console.ReadLine();
                if (change != "") p.Gender = change;
                Console.Write($"Admit Date [{p.AdmitDate}]: ");
                change = Console.ReadLine();
                if (change != "") p.AdmitDate = DateTime.Parse(change);
                Console.Write($"Had Exam [{p.HadExam}]: ");
                change = Console.ReadLine();
                change = change.ToLower();
                if (change == "y" || change == "yes" || change == "true" || change == "t" || change == "1") p.HadExam = true;
                else if (change == "n" || change == "no" || change == "false" || change == "f" || change == "0") p.HadExam = false;
                // Save changes to database
                db.SaveChanges();
            }

        }
        // DischargePatient() answers requirement #7
        static void DischargePatient()
        {
            Console.Write("Enter id of patient to discharge: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new AppDbContext())
            {
                Patient p = db.Patients.Find(id); // Find patient by id
                db.Remove(p); // Remove patient from database
                db.SaveChanges();
            }
        }
        // AdmitPatient() answers requirement #4. This allows user to enter a new patient into the database
        static void AdmitPatient()
        {
            // Gather patient information from the user
            Patient p = new Patient();
            Console.Write("Enter patient first name: ");
            p.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            p.LastName = Console.ReadLine();
            Console.Write("Age: ");
            p.Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gender: ");
            p.Gender = Console.ReadLine();
            Console.Write("Admit date: ");
            p.AdmitDate = DateTime.Parse(Console.ReadLine());
            p.HadExam = false;

            using (var db = new AppDbContext())
            {
                db.Add(p); // Add patient to the database
                db.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            SeedDatabase(); // Put initial patient data from requirement #8 into database
            // Loop that prompts user for task and then executes what user wants
            // This will keep looping until user enters 'q' for quit.
            do
            {
                Console.Write("\n(a)dmit new patient, (l)ist patients, (u)pdate patient, (d)ischarge patient, (q)uit> ");
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "a":
                        AdmitPatient();
                        break;
                    case "l":
                        ListPatients();
                        break;
                    case "u":
                        UpdatePatient();
                        break;
                    case "d":
                        DischargePatient();
                        break;
                    case "q":
                        //System.Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            } while (true);
        }
    }
}
