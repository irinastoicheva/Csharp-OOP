namespace P05.BarrackWarsReturnOfTheDependencies.Core.Factories
{
    using Contracts;
    using System;
   
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type classType = Type.GetType($"P04.BarrackWars_TheCommandsStrikeBack.Models.Units." + unitType);

            IUnit instance = (IUnit)Activator.CreateInstance(classType);

            return instance;
        }
    }
}
