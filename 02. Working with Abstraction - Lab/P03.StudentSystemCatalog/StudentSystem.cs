namespace P03.StudentSystemCatalog
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> students;

        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void Add(string name, int age, double grade)
        {
            if (!students.ContainsKey(name))
            {
                Student student = new Student(name, age, grade);
                students[name] = student;
            }
        }

        public Student Show(string name)
        {
            if (!students.ContainsKey(name))
            {
                throw new ArgumentException($"Student with name - {name} is not exist!");
            }

            Student student = students[name];
            return student;
        }
    }
}