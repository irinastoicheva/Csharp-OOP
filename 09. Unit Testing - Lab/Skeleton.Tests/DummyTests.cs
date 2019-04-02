namespace Skeleton.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int DummyHealth = 10;
        private int DummyExperience = 10;

        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, this.DummyExperience);

            Assert.That(() => dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(1, this.DummyExperience);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Dead dummy doesn't give experience.");
        }

        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            Dummy dummy = new Dummy(-1, this.DummyExperience);

            int experience = dummy.GiveExperience();

            Assert.AreEqual(10, experience);
        }
    }
}
