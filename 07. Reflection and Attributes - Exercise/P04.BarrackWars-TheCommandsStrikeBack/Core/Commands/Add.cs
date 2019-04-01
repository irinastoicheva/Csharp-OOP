using P04.BarrackWars_TheCommandsStrikeBack.Contracts;

namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
