namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    using Contracts;
    public class Report : Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory unitFactory)
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
