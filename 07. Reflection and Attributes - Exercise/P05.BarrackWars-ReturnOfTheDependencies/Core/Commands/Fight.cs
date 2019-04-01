
namespace P05.BarrackWarsReturnOfTheDependencies.Core.Commands
{
    using Contracts;
    using System;
    public class Fight : Command
    {
        public Fight(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
