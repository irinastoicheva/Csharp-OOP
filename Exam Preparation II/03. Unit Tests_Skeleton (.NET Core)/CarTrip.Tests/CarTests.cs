using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Opel", 50, 20, 0.6);
        }

        [Test]
        public void TestConstructorCorrectly()
        {
            Assert.AreEqual("Opel", car.Model);
            Assert.AreEqual(50, car.TankCapacity);
            Assert.AreEqual(20, car.FuelAmount);
            Assert.AreEqual(0.6, car.FuelConsumptionPerKm);
        }

        [Test]
        public void TestGetCarModelCorrectly()
        {
            Assert.AreEqual("Opel", car.Model);
        }

        [Test]
        [TestCase(" ")]
        [TestCase("")]
        public void TestModelForEmptyOrWhiteSpase(string model)
        {
            Assert.That(() => new Car(model, 50, 20 , 0.4), Throws.ArgumentException.With.Message.EqualTo($"Model is required"));
        }

        [Test]
        [TestCase(100)]
        [TestCase(55)]
        public void TestFuelAmountThrowException(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => new Car("Opel", 50, fuelAmount, 0.4));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestFuelConsumptionPerKmThrowException(double fuelConsumptionPerKm)
        {
            Assert.Throws<ArgumentException>(() => new Car("Opel", 50, 20, fuelConsumptionPerKm));
        }


        [Test]
        public void TestGetCarTankCapacity()
        {
            Assert.AreEqual(50, car.TankCapacity);
        }

        [Test]
        public void TestGetCarFuelAmountCorrectly()
        {
            Assert.AreEqual(20, car.FuelAmount);
        }

        [Test]
        public void TestGetCarFuelConsumptionPerKmCorrectly()
        {
            Assert.AreEqual(0.6, car.FuelConsumptionPerKm);
        }

        [Test]
        public void TestDriveCorrectly()
        {
            car.Drive(10);
            Assert.AreEqual(14, car.FuelAmount);
        }

        [Test]
        public void TestDriveThrowInvalidOperationException()
        {
            Assert.That(() => car.Drive(500), Throws.InvalidOperationException.With.Message.EqualTo("Cannot travel this distance"));
        }

        [Test]
        public void TestRefuelCorrectly()
        {
            car.Refuel(10);
            Assert.AreEqual(30, car.FuelAmount);
        }

        [Test]
        public void TestRefuelThrowInvalidOperationException()
        {
            Assert.That(() => car.Refuel(50), Throws.InvalidOperationException.With.Message.EqualTo("Cannot fill 50 in the tank"));
        }

    }
}