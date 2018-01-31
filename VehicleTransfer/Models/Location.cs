using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleTransfer.Models
{
    public class Location
    {
        protected string _name;
        protected List<Vehicle> _vehicles;

        public Location()
        {
            _vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        protected bool transferAllowed(Vehicle vehicle)
        {
            bool transferAllowed = false;

            if (vehicle.status == Vehicle.Status.StandBy)
            {
                transferAllowed = true;
            }

            return transferAllowed;
        }
    }
}