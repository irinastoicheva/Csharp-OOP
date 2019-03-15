namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Doctor
    {
        private List<Patient> patients;

        public Doctor(string name)
        {
            this.Name = name;
            this.patients = new List<Patient>();
        }
        public string Name { get; set; }


        public void AddPatient(Patient patient)
        {
            if (!this.patients.Contains(patient))
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
