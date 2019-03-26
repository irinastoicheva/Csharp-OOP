namespace P08.MilitaryElite
{
    using System.Collections.Generic;

    public class ComparerMissions : IComparer<Mission>
    {
        public int Compare(Mission x, Mission y)
        {
            if (x.Name.CompareTo(y.Name) == 0)
            {
                return x.State.CompareTo(y.State);
            }

            return x.Name.CompareTo(y.Name);
        }
    }
}