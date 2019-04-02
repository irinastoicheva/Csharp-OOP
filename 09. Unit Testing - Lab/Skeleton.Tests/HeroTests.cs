namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGainsXPWhenTargetDies()
        {
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();

            mockTarget.Setup(t => t.GiveExperience()).Returns(() => 55);
            mockTarget.Setup(t => t.IsDead()).Returns(() => true);

            Hero batman = new Hero("batman", mockWeapon.Object);
            batman.Attack(mockTarget.Object);

            Assert.AreEqual(55, batman.Experience);
        }
    }
}
