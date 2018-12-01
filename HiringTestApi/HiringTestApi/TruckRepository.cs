using System.Collections.Generic;
using System.Linq;
using HiringTestApi.Model;

namespace HiringTestApi
{
    public class TruckRepository : ITruckRepository
    {
        private static readonly List<Truck> trucks = new List<Truck>
        {
            new Truck {LicensePlate = "TX19690", Weight = 10.852, Owner = "B. Gibbons"},
            new Truck {LicensePlate = "ZZ86700", Weight = 8.050, Owner = "D. Hill"},
            new Truck {LicensePlate = "ME32485", Weight = 6.66, Owner = "Brdr. Bisp"},
            new Truck {LicensePlate = "AB12345", Weight = 11.321}
        };

        public IEnumerable<Truck> GetAll()
        {
            return trucks;
        }

        public Truck Get(string licensePlate)
        {
            return trucks.FirstOrDefault(t => t.LicensePlate == licensePlate);
        }

        public void Update(string licensePlate, Truck truck)
        {
            // TODO: Update truck in repo
        }

        public void Add(Truck truck)
        {
            trucks.Add(truck);
        }
    }
}