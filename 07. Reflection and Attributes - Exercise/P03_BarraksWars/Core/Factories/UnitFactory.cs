namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type classType = typeof(UnitFactory).Assembly.GetTypes().FirstOrDefault(x => x.Name == unitType);

            IUnit instance = (IUnit)Activator.CreateInstance(classType, false);

            return instance;
        }
    }
}
