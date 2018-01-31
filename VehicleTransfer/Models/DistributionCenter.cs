using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleTransfer.Models
{
    public class DistributionCenter : Location
    {
        private List<Branch> _branches;

        public DistributionCenter(string dcName)
        {
            _name = dcName;
            _branches = new List<Branch>();
            _vehicles = new List<Vehicle>();
        }

        public string distributionCenterName
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

        public List<Branch> branches
        {
            get
            {
                return _branches;
            }
            set
            {
                _branches = value;
            }
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

        public void AddBranch(Branch branch)
        {
            _branches.Add(branch);
        }

        public bool Move(Vehicle remove)
        {
            List<Vehicle> updatedVehicles = new List<Vehicle>();
            bool found = false;

            if (transferAllowed(remove))
            {
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