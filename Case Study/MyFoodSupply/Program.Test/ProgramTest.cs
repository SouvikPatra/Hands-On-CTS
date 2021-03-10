using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MyFoodSupply;

namespace MyFoodSupply.Test
{
    [TestFixture]
    public class ProgramTest
    {
        private Program _program;

        [SetUp]
        public void SetUp()
        {
            _program = new Program();
        }

        //NUnit Test cases for CreateFoodDetail Method
        [Test]
        [TestCase("food", 2, "2021-04-09", 30.12)]
        public void CreateFoodDetail_Check_ReturnFoodDetailObject(string name, int dishType, DateTime expiryDate, double price)
        {
            var result = _program.CreateFoodDetail(name, dishType, expiryDate, price);

            Assert.That(result, Is.TypeOf<FoodDetail>());
        }
        [Test]
        [TestCase(null, 4, "2022-04-19", 10.50)]
        [TestCase("", 3, "2021-05-09", 15.50)]
        public void CreateFoodDetail_FoodNameIsNullOrEmpty(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => _program.CreateFoodDetail(name, dishType, expiryDate, price));
        }
        [Test]
        [TestCase("food1", 3, "2020-04-09", 0)]
        [TestCase("food2", 2, "2021-04-09", -1)]
        public void CreateFoodDetail_PriceLessThanZero(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => _program.CreateFoodDetail(name, dishType, expiryDate, price));
        }
        [Test]
        [TestCase("food1", 2, "2021-02-09", 30.25)]
        public void CreateFoodDetail_ExpiryDateLessThanCurrentDate(string name, int dishType, DateTime expiryDate, double price)
        {
            Assert.Throws<Exception>(() => _program.CreateFoodDetail(name, dishType, expiryDate, price));
        }
        //NUnit Test cases for CreateSupplyDetail Method
        [Test]
        [TestCase(10, "2021-04-10", "seller1", 10.50)]
        public void CreateSupplyDetail_Check_ReturnSupplyDetailObject(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            var foodItem = new FoodDetail()
            {
                Name = "food1",
                DishType = (FoodDetail.Category)1,
                ExpiryDate = new DateTime(2021, 6, 9),
                Price = 20.45
            };

            var result = _program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodItem);

            Assert.That(result, Is.TypeOf<SupplyDetail>());
        }
        [Test]
        [TestCase(0, "2021-04-07", "seller1", 10.50)]
        [TestCase(-1, "2021-04-07", "seller2", 10.50)]
        public void CreateSupplyDetail_FoodItemCountLessThanZero(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            var foodItem = new FoodDetail()
            {
                Name = "food1",
                DishType = (FoodDetail.Category)1,
                ExpiryDate = new DateTime(2021, 5, 8),
                Price = 30.54
            };

            Assert.Throws<Exception>(() => _program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodItem));
        }
        [Test]
        [TestCase(10, "2021-02-07", "seller1", 10.50)]
        public void CreateSupplyDetail_RequestDateLessThanCurrentDate(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge)
        {
            var foodItem = new FoodDetail()
            {
                Name = "food1",
                DishType = (FoodDetail.Category)1,
                ExpiryDate = new DateTime(2021, 5, 8),
                Price = 30.75
            };

            Assert.Throws<Exception>(() => _program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodItem));
        }
        [Test]
        [TestCase(10, "2020-05-27", "seller1", 10.50, null)]
        public void CreateSupplyDetail_NullFoodDetail(int foodItemCount, DateTime requestDate, string sellerName, double packingCharge, FoodDetail foodItem)
        {
            var result = _program.CreateSupplyDetail(foodItemCount, requestDate, sellerName, packingCharge, foodItem);

            Assert.That(result, Is.EqualTo(null));
        }
    }

}
