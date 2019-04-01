namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    using Contracts;
    using Core.Attributes;

    public class ReportCommand : Command
    {
        //[Inject]
        //private IRepository repository;

        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
