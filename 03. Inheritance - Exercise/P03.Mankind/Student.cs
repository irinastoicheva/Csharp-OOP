namespace P03.Mankind
{
    using System;
    using System.Linq;

    public class Student : Human
    {
        private string facultyNumber;
        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            set
            {
                if (value.Length < 5 || value.Length > 10 || !(value.All(x => char.IsLetterOrDigit(x))))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nFaculty number: {this.FacultyNumber}";
        }
    }
}
