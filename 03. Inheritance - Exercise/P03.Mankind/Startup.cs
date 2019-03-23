namespace P03.Mankind
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string facultyNumber = studentInfo[2];
                Student student = new Student(firstName, lastName, facultyNumber);

                string[] workerInfo = Console.ReadLine().Split();
                firstName = workerInfo[0];
                lastName = workerInfo[1];
                double salary = double.Parse(workerInfo[2]);
                double hoursPerDay = double.Parse(workerInfo[3]);

                Worker worker = new Worker(firstName, lastName, salary, hoursPerDay);
                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }          
        }
    }
}
