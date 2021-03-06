﻿using P04.BarrackWars_TheCommandsStrikeBack.Contracts;

namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory) 
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
