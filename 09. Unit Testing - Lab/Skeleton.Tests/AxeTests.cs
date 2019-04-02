namespace Skeleton.Tests
{
    //using FluentAssertions; - very good library!!!
    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
    }
}
