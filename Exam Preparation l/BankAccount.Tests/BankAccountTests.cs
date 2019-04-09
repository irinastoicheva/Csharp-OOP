using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        private BankAccount bankAccount;
        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount("bankAccauntName", 5.00M);
        }

        [Test]
        public void TestingConstructorShouldWorkCorrectly()
        {
            BankAccount bankAccount = new BankAccount("Name", 15.00M);

            Assert.That("Name", Is.EqualTo(bankAccount.Name));
            Assert.That(15.00, Is.EqualTo(bankAccount.Balance));
        }

        [Test]
        public void TestingGetNameShouldWorkCorrectly()
        {
            Assert.That("bankAccauntName", Is.EqualTo(this.bankAccount.Name));
        }

        [Test]
        [TestCase("Ab")]
        [TestCase("")]
        [TestCase("Abcdefghijklmnopqrstuvwxyz")]
        [TestCase("AbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyz")]
        public void TestingSetNameShouldThrowArgumentException(string name)
        {
            Assert.That(() => bankAccount = new BankAccount(name, 2.50M), Throws.ArgumentException.With.Message.EqualTo($"Invalid name length"));
        }

        [Test]
        public void TestingGetBalanceShouldWorkCorrectly()
        {
            Assert.That(5.00, Is.EqualTo(this.bankAccount.Balance));
        }

        [Test]
        [TestCase(-1.00)]
        [TestCase(-5)]
        public void TestingSetBalanceShouldThrowArgumentException(decimal balance)
        {
            Assert.That(() => bankAccount = new BankAccount("bankAccauntName", balance), Throws.ArgumentException.With.Message.EqualTo($"Balance must be positive!"));
        }

        [Test]
        public void TestingDepositShouldWorkCorrectly()
        {
            this.bankAccount.Deposit(1.50M);
            Assert.That(6.50, Is.EqualTo(this.bankAccount.Balance));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1.00)]
        [TestCase(-5)]
        public void TestingDepositShouldThrowInvalidOperationException(decimal deposit)
        {
            Assert.That(() => this.bankAccount.Deposit(deposit), Throws.InvalidOperationException.With.Message.EqualTo($"amount must be positive"));
        }

        [Test]
        public void TestingWithdrawShouldWorkCorrectly()
        {
            this.bankAccount.Withdraw(1.50M);
            Assert.That(3.50, Is.EqualTo(this.bankAccount.Balance));
        }

        [Test]
        [TestCase(6)]
        [TestCase(-1.00)]
        public void TestingWithdrawShouldThrowInvalidOperationException(decimal amount)
        {
            Assert.That(() => this.bankAccount.Withdraw(amount), Throws.InvalidOperationException.With.Message.EqualTo($"amount must be more than 0 and less than your balance"));
        }
    }
}