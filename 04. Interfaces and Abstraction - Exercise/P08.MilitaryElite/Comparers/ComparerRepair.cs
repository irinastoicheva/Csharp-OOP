namespace P08.MilitaryElite
{
    using System.Collections.Generic;
    public class ComparerRepair : IComparer<Repair>
    {
        public int Compare(Repair x, Repair y)
        {
            if (x.Name.CompareTo(y.Name) == 0)
            {
                return x.WorkedHours - y.WorkedHours;
            }

            return x.Name.CompareTo(y.Name);
        }
    }
}
