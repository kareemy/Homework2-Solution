using Homework2;

Hospital myHospital = new Hospital();
myHospital.SeedDatabase(); // Put initial patient data from requirement #8 into database

// Loop that prompts user for task and then executes what user wants
// This will keep looping until user enters 'q' for quit.
do
{
    Console.Write("\n(a)dmit new patient, (l)ist patients, (u)pdate patient, (d)ischarge patient, (q)uit> ");
    string? cmd = Console.ReadLine();
    switch (cmd)
    {
        case "a":
            myHospital.AddPatient();
            break;
        case "l":
            myHospital.ListPatients();
            break;
        case "u":
            myHospital.UpdatePatient();
            break;
        case "d":
            myHospital.RemovePatient();
            break;
        case "q":
            //System.Environment.Exit(0);
            return;
        default:
            Console.WriteLine("Invalid command.");
            break;
    }
} while (true);