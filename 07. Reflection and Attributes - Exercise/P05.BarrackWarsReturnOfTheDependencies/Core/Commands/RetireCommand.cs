namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    using Contracts;
    using Core.Commands;
    using Core.Attributes;

    public class RetireCommand : Command
    {
        //[Inject]
        //private IRepository repository;

        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
