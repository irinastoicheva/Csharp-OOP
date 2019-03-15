namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        private List<Department> departments;
        private List<Doctor> doctors;
        public Hospital()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }
        public void AddDoctor(Doctor doctor)
        {
            if (!this.doctors.Contains(doctor))
            {
                this.doctors.Add(doctor);
         
            }
        }

        public void AddDepartment(Department department)
        {
            if (!this.departments.Contains(department))
            {
                this.departments.Add(department);
            }
        }

        public Department GetDepartment(string name)
        {
            Department department;
            if (this.departments.Any(x => x.Name == name))
            {
                department = this.departments.FirstOrDefault(x => x.Name == name);
            }
            else
            {
                department = new Department(name);
                AddDepartment(department);
            }
            return department;
        }

        public Doctor GetDoctor(string name)
        {
            Doctor doctor;
            if (this.doctors.Any(x => x.Name == name))
            {
                doctor = doctors.FirstOrDefault(x => x.Name == name);
            }
            else
            {
                doctor = new Doctor(name);
                AddDoctor(doctor);
            }

            return doctor;
        }
    }
}
