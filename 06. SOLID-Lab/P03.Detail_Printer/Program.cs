namespace P03.DetailPrinter
{
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            IList<Employee> employees = new List<Employee>();

            Employee employee = new Employee("Ivan");
            employees.Add(employee);

            ICollection<string> list = new List<string> { "text 1", "text 2", "text 3" };
            Employee menager = new Manager("Georgi", list);
            employees.Add(menager);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
