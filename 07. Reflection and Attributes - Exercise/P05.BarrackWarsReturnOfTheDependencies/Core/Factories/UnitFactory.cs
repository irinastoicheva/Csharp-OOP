namespace P05.BarrackWarsReturnOfTheDependencies.Core.Factories
{
    using Contracts;
    using System;
    using System.Linq;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type classType = typeof(UnitFactory).Assembly.GetTypes().FirstOrDefault(x => x.Name == unitType); ;

            IUnit instance = (IUnit)Activator.CreateInstance(classType);

            return instance;
        }
    }
}
