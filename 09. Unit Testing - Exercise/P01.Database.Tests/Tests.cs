namespace Tests
{
    using NUnit.Framework;
    using P01.Database;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Tests
    {
        private Database database;
        [SetUp]
        public void SetUp()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhitInvalidParamerer()
        {
            for (int i = 0; i < 10; i++)
            {
                database.Add(45);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(222));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 5; i++)
            {
                this.database.Add(45);
            }

            Assert.That(11, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void RemoveMethodThrowExcetionWhitEmptyDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 5; i++)
            {
                this.database.Remove();
            }

            Assert.That(1, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void ConstructorShouldInicializeCorrectly()
        {
            this.database = new Database(1, 2, 3, 4, 5);

            Assert.That(5, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0)]
        public void ConstructorShouldThrowException(params int[] collection)
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(collection));
        }

        [Test]
        public void PropertyDatabaseElementsShouldSetCorrectly()
        {
            var inputCollection = new List<int>() { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AreEqual(inputCollection, this.database.DatabaseElements);
        }

        [Test]
        public void PropertyDatabaseElementsShouldGetCorrectly()
        {
            int count = 6;

            Assert.That(count, Is.EqualTo(this.database.DatabaseElements.Length));
        }
    }
}