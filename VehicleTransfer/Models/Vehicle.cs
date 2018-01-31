using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace VehicleTransfer.Models
{
    public class Vehicle
    {
        public enum Types
        {
            Truck,
            Van,
            Semis
        }

        public enum Status
        {
            StandBy,
            InTransit,
            InService,
            InRepair
        }

        private string _make;
        private string _model;
        private string _year;
        private string _VIN;
        private Types _type;
        private Status _status;

        public Vehicle()
        {
            _make = null;
            _model = null;
            _year = null;
            _VIN = null;
        }

        public Vehicle(string make, string model, string year, string VIN, Types type)
        {
            _make = make;
            _model = model;

            if (ValidateYear(year))
            {
                _year = year;
            }
            else
            {
                _year = null;
            }

            if (ValidateVIN(VIN))
            {
                _VIN = VIN;
            }
            else
            {
                _VIN = null;
            }

            _type = type;

            _status = Status.StandBy;
        }

        public string make
        {
            get
            {
                return _make;
            }
            set
            {
                _make = value;
            }
        }

        public string model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        public string year
        {
            get
            {
                return _year;
            }
            set
            {
                if (ValidateYear(value))
                {
                    _year = value;
                }
                else
                {
                    _year = null;
                }
            }
        }

        public string VIN
        {
            get
            {
                return _VIN;
            }
            set
            {
                if (ValidateVIN(value))
                {
                    _VIN = value;
                }
                else
                {
                    _VIN = null;
                }
            }
        }

        public Types type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public Status status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }


        private bool ValidateYear(string year)
        {
            var regex = new Regex("^[0-9]+$");
            if (year.Length == 4 && regex.IsMatch(year))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateVIN(string VIN)
        {
            var regex = new Regex(@"^[a-zA-Z0-9]{8,24}([0-9]{5}\b)$");
            if (VIN.Length == 24 && regex.IsMatch(VIN))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transfer(Branch from, Branch to)
        {
            bool transferred = false;

            transferred = from.Move(this);

            if (transferred)
            {
                to.Move(this);
            }

            return transferred;            
        }

        public bool Transfer(DistributionCenter from, DistributionCenter to)
        {
            bool transferred = false;

            transferred = from.Move(this);

            if (transferred)
            {
                to.Move(this);
            }

            return transferred;
        }

        public bool Transfer(DistributionCenter from, Branch to)
        {
            bool transferred = false;

            if (_type == Types.Truck || _type == Types.Van) // Allow only trucks and vans to go from a distribution center to a branch
            {
                transferred = from.Move(this);

                if (transferred)
                {
                    to.Move(this);
                }
            }

            return transferred;
        }
        public bool Transfer(Branch from, DistributionCenter to)
        {
            bool transferred = false;

            if (_type == Types.Truck || _type == Types.Van) // Allow only trucks and vans to go from a distribution center to a branch
            {
                transferred = from.Move(this);

                if (transferred)
                {
                    to.Move(this);
                }
            }

            return transferred;
        }
    }
}