using System.Collections.Generic;

namespace _04.Hospital
{
    public class ComparerDepartment : IComparer<Department>
    {
        public int Compare(Department x, Department y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
