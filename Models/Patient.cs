using System;

namespace Homework2
{
    // Patient entity class with appropriate properties
    // Remember: Even if it is not mentioned in the homework, you need a primary key
    // PatientId is the primary key
    public class Patient
    {
        public int PatientId {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public int Age {get; set;}
        public string Gender {get; set;} = string.Empty;
        public DateTime AdmitDate {get; set;}
        public bool HadExam {get; set;}
    }
}