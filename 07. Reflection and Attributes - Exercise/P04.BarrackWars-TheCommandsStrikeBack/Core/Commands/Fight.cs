using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
using System;

namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
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
