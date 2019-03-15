namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        private List<Room> rooms;
        private List<Patient> patients;
        public Department(string name)
        {
            this.Name = name;
            this.rooms = new List<Room>();
            this.patients = new List<Patient>();
        }
        public string Name { get; set; }

        public void AddPatient(Patient patient)
        {
            if (this.patients.Count < 60)
            {
                this.patients.Add(patient);
            }
        }

        public int GetCountPatients()
        {
            return this.patients.Count;
        }

        public Room GetRoom()
        {
            Room room;
            if (this.patients.Count % 3 != 0)
            {
                room = rooms.FirstOrDefault(x => x.Name == this.patients.Count / 3 + 1);
            }
            else
            {
                room = new Room(this.patients.Count / 3 + 1, this.Name);
                this.rooms.Add(room);
            }

            return room;
        }

        public Room GetRoom(int number)
        {
            return this.rooms[number - 1];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.patients)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
