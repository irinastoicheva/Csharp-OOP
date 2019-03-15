namespace _04.Hospital
{
    using System.Collections.Generic;

    public class ComparerDoctor : IComparer<Doctor>
    {
        public int Compare(Doctor x, Doctor y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
