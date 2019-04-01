namespace P04.BarrackWars_TheCommandsStrikeBack.Core
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
    using System;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1);
            Type unitType = Type.GetType("P04.BarrackWars_TheCommandsStrikeBack.Core.Commands." + commandName);
            var instance = (IExecutable)Activator.CreateInstance(unitType, new object[] { data, repository, unitFactory });
            string result = instance.Execute();
            return result;
        }


        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        // private string AddUnitCommand(string[] data)
        // {
        //string unitType = data[1];
        //IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //this.repository.AddUnit(unitToAdd);
        //string output = unitType + " added!";
        //return output;
        // }
    }
}
