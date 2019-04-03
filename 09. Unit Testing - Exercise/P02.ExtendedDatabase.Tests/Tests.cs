namespace Tests
{
    using Moq;
    using NUnit.Framework;
    using P02.ExtendedDatabase;
    using P02.ExtendedDatabase.Tests;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class Tests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database(new FakeFirstPerson(1, "Pesho"), new FakeFirstPerson(2, "Ivan"));
        }

        [Test]
        public void ChecksForTheExistenceWithCorrectlyName()
        {
            var fakePerson = new FakeFirstPerson(3, "Gosho");

            bool isPossible = database.ChecksForTheExistenceOfThisPerson(fakePerson);

            Assert.AreEqual(true, database.ChecksForTheExistenceOfThisPerson(fakePerson));
        }

        [Test]
        public void ChecksForTheExistenceWithIncorectlyName()
        {
            var fakePerson = new FakeFirstPerson(3, "Pesho");

            bool isPossible = database.ChecksForTheExistenceOfThisPerson(fakePerson);

            Assert.AreEqual(false, database.ChecksForTheExistenceOfThisPerson(fakePerson));
        }

        [Test]
        public void ChecksForTheExistenceWithCorrectlyId()
        {
            var fakePerson = new FakeFirstPerson(3, "Gosho");

            bool isPossible = database.ChecksForTheExistenceOfThisPerson(fakePerson);

            Assert.AreEqual(true, database.ChecksForTheExistenceOfThisPerson(fakePerson));
        }

        [Test]
        public void ChecksForTheExistenceWithIncorectlyId()
        {
            var fakePerson = new FakeFirstPerson(1, "Pesho");

            bool isPossible = database.ChecksForTheExistenceOfThisPerson(fakePerson);

            Assert.AreEqual(false, database.ChecksForTheExistenceOfThisPerson(fakePerson));
        }

        [Test]
        public void FindByIdShouldCorrectly()
        {
            long id = 1;

            IPerson person = database.FindById(id);
            IPerson anotherPerson = new Person(1, "Pesho");

            Assert.AreEqual(anotherPerson.Id, person.Id);
            Assert.AreEqual(anotherPerson.Name, person.Name);
        }

        [Test]
        public void FindByIdShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(5));
        }

        [Test]
        public void FindByIdShouldThrowArgumentOutOfRangeException()
        {
            Database database = new Database(new FakeFirstPerson(-5, "Pesho"), new FakeFirstPerson(3, "Ivan"));

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-5));
        }

        [Test]
        public void FindByNameShouldCorrectly()
        {
            IPerson person = database.FindByUsername("Pesho");
            IPerson anotherPerson = new Person(1, "Pesho");

            Assert.AreEqual(anotherPerson.Id, person.Id);
            Assert.AreEqual(anotherPerson.Name, person.Name);
        }

        [Test]
        public void FindByNameShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));
        }

        [Test]
        public void RemoveShouldCorrectly()
        {
            database.Remove();
            int counter = database.DatabaseElements.Length;
            Assert.AreEqual(1, counter);
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationException()
        {
            database.Remove();
            database.Remove();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void AddShouldCorrectly()
        {
            FakeFirstPerson fakeFirstPerson = new FakeFirstPerson(5, "Gosho");

            database.Add(fakeFirstPerson);
            IPerson person = database.DatabaseElements[2];

            Assert.AreEqual(fakeFirstPerson.Id, person.Id);
            Assert.AreEqual(fakeFirstPerson.Name, person.Name);
        }

        [Test]
        public void AddWhitVeryElementsShouldInvalidOperationExceptionWhit()
        {
            for (int i = 0; i < 15; i++)
            {
                FakeFirstPerson fakeFirstPerson = new FakeFirstPerson(3 + i, (string.Concat("Gosho"), i).ToString());

                if (i == 14)
                {
                    Assert.Throws<InvalidOperationException>(() => database.Add(fakeFirstPerson));
                }
                else
                {
                    database.Add(fakeFirstPerson);
                }
            }
        }

        [Test]
        public void AddWhitIncorectNameElementsShouldInvalidOperationExceptionWhit()
        {
            FakeFirstPerson person = new FakeFirstPerson(5, "Pesho");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void AddWhitIncorectIdElementsShouldInvalidOperationExceptionWhit()
        {
            FakeFirstPerson person = new FakeFirstPerson(1, "Ana");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void CostructorWithEmptyCollectionShouldInvalidOperationExceptionWhit()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database());
        }

        [Test]
        public void CostructorWithVeryBigCollectionShouldInvalidOperationExceptionWhit()
        {
            ICollection<IPerson> people = new List<IPerson>();
            for (int i = 0; i < 20; i++)
            {
                FakeFirstPerson fakeFirstPerson = new FakeFirstPerson(3 + i, (string.Concat("Gosho"), i).ToString());
                people.Add(fakeFirstPerson);
            }

            Assert.Throws<InvalidOperationException>(() => database = new Database(people.ToArray()));
        }

        [Test]
        public void CostructorWithCollectionWhitEqalNameShouldInvalidOperationExceptionWhit()
        {
            ICollection<IPerson> people = new List<IPerson>();
            for (int i = 0; i < 2; i++)
            {
                FakeFirstPerson fakeFirstPerson = new FakeFirstPerson(3 + i, "Gosho");
                people.Add(fakeFirstPerson);
            }

            Assert.Throws<InvalidOperationException>(() => database = new Database(people.ToArray()));
        }

        [Test]
        public void CostructorWithCollectionEqualIdShouldInvalidOperationExceptionWhit()
        {
            ICollection<IPerson> people = new List<IPerson>();
            for (int i = 0; i < 20; i++)
            {
                FakeFirstPerson fakeFirstPerson = new FakeFirstPerson(3 + i, (string.Concat("Gosho"), 5).ToString());
                people.Add(fakeFirstPerson);
            }

            Assert.Throws<InvalidOperationException>(() => database = new Database(people.ToArray()));
        }

    }
}