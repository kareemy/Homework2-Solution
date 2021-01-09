using System;

namespace Homework2
{
    // Patient entity class with appropriate properties
    // Remember: Even if it is not mentioned in the homework, you need a primary key
    // PatientId is the primary key
    public class Patient
    {
        public int PatientId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int Age {get; set;}
        public string Gender {get; set;}
        public DateTime AdmitDate {get; set;}
        public bool HadExam {get; set;}
    }
}