using System.Collections.Generic;
using HiringTestApi.Model;

namespace HiringTestApi
{
    public interface ITruckRepository
    {
        IEnumerable<Truck> GetAll();
        Truck Get(string licensePlate);
        void Update(string licensePlate, Truck truck);
        void Add(Truck truck);
    }
}