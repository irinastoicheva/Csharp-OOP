namespace P03_StudentSystem
{
    using System;
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();
            while (true)
            {
                studentSystem.ParseCommand();
            }
        }
    }
}
