using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleTransfer.Models
{
    public class Branch : Location
    {
        public Branch(string branchName)
        {
            name = branchName;
            _vehicles = new List<Vehicle>();
        }

        public List<Vehicle> vehicles
        {
            get
            {
                return _vehicles;
            }
            set
            {
                _vehicles = value;
            }
        }

        public bool Move(Vehicle remove)
        {
            List<Vehicle> updatedVehicles = new List<Vehicle>();
            bool found = false;

            if (
                transferAllowed(remove)
                && (remove.type == Vehicle.Types.Truck || remove.type == Vehicle.Types.Van)
                )
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle != remove)
                {
                    updatedVehicles.Add(vehicle);
                }
                else
                {
                    found = true;
                }
            }

            return found;
        }

        public bool Receive(Vehicle add)
        {
            bool transferred = false;

            bool alreadyExists = _vehicles.Exists(x => x == add);

            if (transferAllowed(add) && !alreadyExists)
            {
                _vehicles.Add(add);
                transferred = true;
            }

            return transferred;
        }
    }
}