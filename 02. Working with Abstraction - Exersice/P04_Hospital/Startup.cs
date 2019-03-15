namespace _04.Hospital
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Hospital hospital = new Hospital();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] parts = command.Split();
                string departamentName = parts[0];
                string firstName = parts[1];
                string family = parts[2];
                string doctorName = firstName + family;
                string patientName = parts[3];

                Department department = hospital.GetDepartment(departamentName);

                if (department.GetCountPatients() < 60)
                {
                    Room room = department.GetRoom();
                    Patient patient = new Patient(patientName);
                    room.AddPatient(patient);
                    department.AddPatient(patient);
                    Doctor doctor = hospital.GetDoctor(doctorName);
                    doctor.AddPatient(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandParts = command.Split();

                if (commandParts.Length == 1)
                {
                    Department department = hospital.GetDepartment(commandParts[0]);
                    Console.WriteLine(department);
                }
                else if (commandParts.Length == 2 && int.TryParse(commandParts[1], out int numberOfRoom))
                {
                    string departmentName = commandParts[0];
                    Department department = hospital.GetDepartment(departmentName);
                    int roomName = int.Parse(commandParts[1]);
                    Room room = department.GetRoom(roomName);
                    Console.WriteLine(room);
                }
                else
                {
                    string doctorName = commandParts[0] + commandParts[1];
                    Doctor doctor = hospital.GetDoctor(doctorName);
                    Console.WriteLine(doctor);
                }
                command = Console.ReadLine();
            }
        }
    }
}
