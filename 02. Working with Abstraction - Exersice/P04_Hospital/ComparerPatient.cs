using System.Collections.Generic;

namespace _04.Hospital
{
    public class ComparerPatient : IComparer<Patient>
    {
        public int Compare(Patient x, Patient y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
