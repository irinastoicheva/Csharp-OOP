namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Factories
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
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
