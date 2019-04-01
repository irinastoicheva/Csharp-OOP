namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    using Contracts;
    using Core.Attributes;

    public class AddCommand : Command
    {
        //[Inject]
        //private IRepository repository;
        //[Inject]
        //private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
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
