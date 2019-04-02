namespace Skeleton.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        [SetUp]
        public void SetUp()
        {
            //Изпълнява се автоматично преди всеки тест
        }

        [TearDown]
        public void TearDoun()
        {
            //Изпълнява се след всеки тест
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 5);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(1, 5);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            Dummy dummy = new Dummy(-1, 5);

            int experience = dummy.GiveExperience();

            Assert.AreEqual(5, experience);
        }



        //[Test]
        //public void DeadDummy()
        //{
        //    //Arrange
        //    Dummy dummy = new Dummy(0, 10);

        //    //Act + Assert
        //    Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        //}

        //[Test]
        //[TestCase(20, true)]
        //[TestCase(10, false)]
        //[TestCase(100, true)]
        //public void GiveExperience(int dummyHealth, string property)
        //{
        //    //Arrange
        //    Dummy dummy = new Dummy(dummyHealth, 10);

        //    //Act 
        //    int exp = dummy.GiveExperience();

        //    //Assert
        //    exp.Should().Be(10);
        //}

        //[Test]
        //public void CantGiveExperionce()
        //{
        //    //Arrange
        //    Dummy dummy = new Dummy(2, 10);

        //    //Act 
        //    //Assert
        //    Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        //}
    }
}
