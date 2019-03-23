namespace P03.Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private double hoursPerDay;
        public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }
        public double HoursPerDay
        {
            get => this.hoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.hoursPerDay = value;
            }
        }

        public double SalaryForHour()
        {
            return this.weekSalary / 5 / this.hoursPerDay ;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
            sb.AppendLine($"Hours per day: {this.HoursPerDay:F2}");
            sb.AppendLine($"Salary per hour: {SalaryForHour():F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
