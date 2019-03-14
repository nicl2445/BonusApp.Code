using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BonusApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Order order;

        [TestInitialize]
        public void InitializeTest()
        {
            order = new Order();
            order.AddProduct(new Product
            {
                Name = "Mælk",
                Value = 10.0
            });
            order.AddProduct(new Product
            {
                Name = "Smør",
                Value = 15.0
            });
            order.AddProduct(new Product
            {
                Name = "Pålæg",
                Value = 20.0
            });
        }
        [TestMethod]
        public void GetBonusAnonymous_Test()
        {
            order.Bonus = delegate (double amount) { return amount / 10.0; };

            order.Bonus = delegate (double amount) { return amount > 5.0 ? 2.0 : 0.0; };
        }

        [TestMethod]
        public void TenPercent_Test()
        {
            Assert.AreEqual(4.5, Bonuses.TenPercent(45.0));
            Assert.AreEqual(40.0, Bonuses.TenPercent(400.0));
        }
        [TestMethod]
        public void FlatTwoIfAMountMoreThanFive_Test()
        {
            Assert.AreEqual(2.0, Bonuses.FlatTwoIfAmountMoreThanFive(10.0));
            Assert.AreEqual(0.0, Bonuses.FlatTwoIfAmountMoreThanFive(4.0));
        }
        [TestMethod]
        public void GetValueOfProducts_Test()
        {
            Assert.AreEqual(45.0, order.GetValueOfProducts());
        }
        [TestMethod]
        public void GetBonus_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(4.5, order.GetBonus());

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(2.0, order.GetBonus());
        }
        [TestMethod]
        public void GetTotalPrice_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(40.5, order.GetTotalPrice());

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(43.0, order.GetTotalPrice());
        }
        [TestMethod]
        public void GetBonusLambda_Test()
        {
            order.Bonus = (x) => x/10.0 ; // <- Change to lambda expression
            Assert.AreEqual(4.5, order.GetBonus());

            order.Bonus = (x) => x > 5.0 ? 2.0 : 0.0; ; // <- Change to lambda expression
            Assert.AreEqual(2.0, order.GetBonus());
        }
        [TestMethod]
        public void GetBonusByLambdaParameter_Test()
        {
            // Use TenPercent lambda expresssion as parameter to GetBonus
            Assert.AreEqual(4.5, order.GetBonus(Bonuses.TenPercent));

            // Use FlatTwoIfAmountMoreThanFive lambda expresssion as parameter to GetBonus
            Assert.AreEqual(2.0, order.GetBonus(Bonuses.FlatTwoIfAmountMoreThanFive));
        } 

    }

}
