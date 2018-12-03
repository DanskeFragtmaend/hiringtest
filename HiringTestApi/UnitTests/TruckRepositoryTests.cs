using System.Linq;
using HiringTestApi;
using HiringTestApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TruckRepositoryTests
    {
        [TestMethod]
        public void GetAll_Test()
        {
            var repo = new TruckRepository();
            var trucks = repo.GetAll();
            Assert.AreEqual(4, trucks.Count(), "4 trucks");
        }

        [TestMethod]
        public void Get_Test()
        {
            var repo = new TruckRepository();
            repo.Add(new Truck { LicensePlate = "asdf12344567", Owner = "Donald Duck", Weight = 123.456 });
            var truck = repo.Get("asdf12344567");
            Assert.IsNotNull(truck);
            Assert.AreEqual("asdf12344567", truck.LicensePlate, "LicencePlate");
            Assert.AreEqual("Donald Duck", truck.Owner, "Owner");
            Assert.AreEqual(123.456, truck.Weight, "Weight");
        }

        [TestMethod]
        public void Update_Test()
        {
            // TODO: Write repository update test
        }
    }
}