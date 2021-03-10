using NUnit.Framework;
using System;

namespace GenericMedicine.UnitTest
{
    [TestFixture]
    public class ProgramTests
    {
        private Program _program;

        [SetUp]
        public void SetUp()
        {
            _program = new Program();
        }

        // NUnit test cases for Create Medicine detail
        [Test]
        [TestCase("medicine1", "generic1", "composition1", "2022-05-28", 20)]
        public void CreateMedicineDetail_ReturnMedicineObject(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            var result = _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip);

            Assert.That(result, Is.TypeOf<Medicine>());
        }

        [Test]
        [TestCase("medicine1", null, "composition1", "2022-05-28", 15)]
        [TestCase("medicine2", "", "comosition2", "2021-06-10", 12)]
        public void CreateMedicineDetail_GenericMedicineNameIsNullOrEmpty_ReturnException(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
        }

        [Test]
        [TestCase("medicine1", "generic1", "composition1", "2022-05-28", 5)]
        [TestCase("medicine2", "generic2", "composition2", "2023-05-28", -1)] 
        public void CreateMedicineDetail_PricePerStripIsLessThanOrEqualZero_ReturnException(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
        }

        [Test]
        [TestCase("medicine1", "generic1", "composition1", "2020-04-08", 9)]
        public void CreateMedicineDetail_ExpiryDateLessThanCurrentDate_ReturnException(string name, string genericMedicineName, string composition, DateTime expiryDate, double pricePerStrip)
        {
            Assert.Throws<Exception>(() => _program.CreateMedicineDetail(name, genericMedicineName, composition, expiryDate, pricePerStrip));
        }

        // NUnit test cases for Carton detail
        [Test]
        [TestCase(1, "2021-04-08", "address1")]
        public void CreateCartonDetail_ReturnCartonObject(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            var medicine = new Medicine()
            {
                Name = "medicine1",
                GenericMedicineName = "generic1",
                Composition = "composition1",
                ExpiryDate = new DateTime(2021, 5, 8),
                PricePerStrip = 15
            };

            var result = _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine);

            Assert.That(result, Is.TypeOf<CartonDetail>());
        }

        [Test]
        [TestCase(0, "2021-04-08", "address1")]
        [TestCase(-1, "2021-04-08", "address2")]
        public void CreateCartonDetail_MedicineStripCountIsLessOrEqualZero_ReturnExceptiom(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            var medicine = new Medicine()
            {
                Name = "medicine1",
                GenericMedicineName = "generic1",
                Composition = "composition1",
                ExpiryDate = new DateTime(2021, 4, 7),
                PricePerStrip = 17
            };

            Assert.Throws<Exception>(() => _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
        }
         
        [Test]
        [TestCase(1, "2020-04-08", "address1")]
        public void CreateCartonDetail_LaunchDateLessThanCurrentDate_ReturnExceptiom(int medicineStripCount, DateTime launchDate, string retailerAddress)
        {
            var medicine = new Medicine()
            {
                Name = "medicine1",
                GenericMedicineName = "generic1",
                Composition = "composition1",
                ExpiryDate = new DateTime(2021, 5, 8),
                PricePerStrip = 10
            };

            Assert.Throws<Exception>(() => _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine));
        }

        [Test]
        [TestCase(1, "2021-04-08", "abc", null)]
        public void CreateCartonDetail_IfMedicineIsNull_ReturnNull(int medicineStripCount, DateTime launchDate, string retailerAddress, Medicine medicine)
        {
            var result = _program.CreateCartonDetail(medicineStripCount, launchDate, retailerAddress, medicine);

            Assert.That(result, Is.EqualTo(null));
        }
    }
}
