using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    public class Room
    {
        private List<Patient> patients { get; set; }

        public Room(int name, string department)
        {
            this.Name = name;
            this.DepartmentName = department;
            this.patients = new List<Patient>();
        }
        public int Name { get; set; }
        public string DepartmentName { get; set; }

        public void AddPatient(Patient patient)
        {
            if (this.patients.Count < 3)
            {
                this.patients.Add(patient);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.patients.OrderBy(x => x.Name))
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
