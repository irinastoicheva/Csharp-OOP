using P04.BarrackWars_TheCommandsStrikeBack.Contracts;

namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
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
