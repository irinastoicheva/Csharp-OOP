using System.Collections.Generic;

namespace P08.MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        HashSet<Private> Privates { get; }
    }
}