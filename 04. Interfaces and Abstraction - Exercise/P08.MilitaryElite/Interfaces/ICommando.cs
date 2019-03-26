using System.Collections.Generic;

namespace P08.MilitaryElite
{
    public interface ICommando : IPrivate, ISpecialisedSoldier
    {
        HashSet<Mission> Missions { get; }
    }
}