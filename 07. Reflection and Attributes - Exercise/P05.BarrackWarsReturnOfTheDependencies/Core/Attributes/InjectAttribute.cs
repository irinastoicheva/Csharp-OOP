namespace P05.BarrackWarsReturnOfTheDependencies.Core.Attributes
{
    using Contracts;
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
        public IRepository repository { get; set; }
        public IUnitFactory unitFactory { get; set; }
    }
}
