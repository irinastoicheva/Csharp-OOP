using System.Collections.Generic;

namespace P08.MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier, IPrivate
    {
        HashSet<Repair> Repairs { get; }
    }
}