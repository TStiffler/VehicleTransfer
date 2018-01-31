using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleTransfer.Models;

namespace VehicleTransfer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VIN_Ends_In_Numerics()
        {
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "12345678901234567890123b", Vehicle.Types.Truck);
            string fordVIN = Ford.VIN; // fordVIN should be null because it was an invalid VIN

            Assert.AreEqual(null, fordVIN);
        }

        [TestMethod]
        public void VIN_Less_Than_24_Characters()
        {
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "12345678901234567890123", Vehicle.Types.Truck);
            string fordVIN = Ford.VIN;  // fordVIN should be null because it had less than 24 characters

            Assert.AreEqual(null, fordVIN);
        }

        [TestMethod]
        public void Year_Is_4_Digits()
        {
            Vehicle Ford = new Vehicle("Ford", "F-150", "18", "123456789012345678901234", Vehicle.Types.Truck);
            string fordYear = Ford.year; // fordYear should be null because it had less than 4 characters

            Assert.AreEqual(null, fordYear);
        }

        [TestMethod]
        public void Add_Branches_To_DC()
        {
            // Creating multiple vehicles
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "123456789012345678901234", Vehicle.Types.Truck);
            Vehicle Sienna = new Vehicle("Toyota", "Sienna", "2017", "432109876543210987654321", Vehicle.Types.Van);
            Vehicle Semi_1001 = new Vehicle("Mack", "Semi_1001", "2005", "134679134679134679134679", Vehicle.Types.Semis);
            Vehicle Semi_1002 = new Vehicle("Mack", "Semi_1002", "2006", "834679134679134679134679", Vehicle.Types.Semis);

            // Creating multiple distribution centers
            DistributionCenter Indy = new DistributionCenter("Indy");
            DistributionCenter Kokomo = new DistributionCenter("Kokomo");

            // Creating multiple branches
            Branch Indy_101 = new Branch("Indy_101");
            Branch Indy_202 = new Branch("Indy_202");
            Branch Kok_101 = new Branch("Kok_101");

            Indy.AddBranch(Indy_101);
            Indy.AddBranch(Kok_101);

            Assert.AreEqual(2, Indy.branches.Count);
        }

        [TestMethod]
        public void Add_Semis()
        {
            // Creating multiple vehicles
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "123456789012345678901234", Vehicle.Types.Truck);
            Vehicle Sienna = new Vehicle("Toyota", "Sienna", "2017", "432109876543210987654321", Vehicle.Types.Van);
            Vehicle Semi_1001 = new Vehicle("Mack", "Semi_1001", "2005", "134679134679134679134679", Vehicle.Types.Semis);
            Vehicle Semi_1002 = new Vehicle("Mack", "Semi_1002", "2006", "834679134679134679134679", Vehicle.Types.Semis);

            // Creating multiple distribution centers
            DistributionCenter Indy = new DistributionCenter("Indy");
            DistributionCenter Kokomo = new DistributionCenter("Kokomo");

            // Creating multiple branches
            Branch Indy_101 = new Branch("Indy_101");
            Branch Indy_202 = new Branch("Indy_202");
            Branch Kok_101 = new Branch("Kok_101");

            Indy.AddVehicle(Semi_1001);
            Kokomo.AddVehicle(Semi_1002);

            Assert.AreEqual(1, Indy.vehicles.Count);
            Assert.AreEqual(1, Kokomo.vehicles.Count);
        }

        [TestMethod]
        public void AddVehicles()
        {
            // Creating multiple vehicles
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "123456789012345678901234", Vehicle.Types.Truck);
            Vehicle Sienna = new Vehicle("Toyota", "Sienna", "2017", "432109876543210987654321", Vehicle.Types.Van);
            Vehicle Semi_1001 = new Vehicle("Mack", "Semi_1001", "2005", "134679134679134679134679", Vehicle.Types.Semis);
            Vehicle Semi_1002 = new Vehicle("Mack", "Semi_1002", "2006", "834679134679134679134679", Vehicle.Types.Semis);

            // Creating multiple distribution centers
            DistributionCenter Indy = new DistributionCenter("Indy");
            DistributionCenter Kokomo = new DistributionCenter("Kokomo");

            // Creating multiple branches
            Branch Indy_101 = new Branch("Indy_101");
            Branch Indy_202 = new Branch("Indy_202");
            Branch Kok_101 = new Branch("Kok_101");

            Indy_101.AddVehicle(Ford);
            Indy_202.AddVehicle(Sienna);

            Assert.AreEqual(1, Indy_101.vehicles.Count);
            Assert.AreEqual(1, Indy_202.vehicles.Count);
        }

        [TestMethod]
        public void Transfer_Semi_To_Branch()
        {
            // Creating multiple vehicles
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "123456789012345678901234", Vehicle.Types.Truck);
            Vehicle Sienna = new Vehicle("Toyota", "Sienna", "2017", "432109876543210987654321", Vehicle.Types.Van);
            Vehicle Semi_1001 = new Vehicle("Mack", "Semi_1001", "2005", "134679134679134679134679", Vehicle.Types.Semis);
            Vehicle Semi_1002 = new Vehicle("Mack", "Semi_1002", "2006", "834679134679134679134679", Vehicle.Types.Semis);

            // Creating multiple distribution centers
            DistributionCenter Indy = new DistributionCenter("Indy");
            DistributionCenter Kokomo = new DistributionCenter("Kokomo");

            // Creating multiple branches
            Branch Indy_101 = new Branch("Indy_101");
            Branch Indy_202 = new Branch("Indy_202");
            Branch Kok_101 = new Branch("Kok_101");

            Indy_101.AddVehicle(Ford);
            Indy_202.AddVehicle(Sienna);

            var semiTransferSuccess = Semi_1001.Transfer(Indy, Indy_101); // Should return false because a semi cannot be transferred to a branch

            Assert.AreEqual(false, semiTransferSuccess);
        }

        [TestMethod]
        public void Transfer_In_Repair_Vehicle()
        {
            // Creating multiple vehicles
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "123456789012345678901234", Vehicle.Types.Truck);
            Vehicle Sienna = new Vehicle("Toyota", "Sienna", "2017", "432109876543210987654321", Vehicle.Types.Van);
            Vehicle Semi_1001 = new Vehicle("Mack", "Semi_1001", "2005", "134679134679134679134679", Vehicle.Types.Semis);
            Vehicle Semi_1002 = new Vehicle("Mack", "Semi_1002", "2006", "834679134679134679134679", Vehicle.Types.Semis);

            // Creating multiple distribution centers
            DistributionCenter Indy = new DistributionCenter("Indy");
            DistributionCenter Kokomo = new DistributionCenter("Kokomo");

            // Creating multiple branches
            Branch Indy_101 = new Branch("Indy_101");
            Branch Indy_202 = new Branch("Indy_202");
            Branch Kok_101 = new Branch("Kok_101");

            Indy_101.AddVehicle(Ford);
            Indy_202.AddVehicle(Sienna);

            Ford.status = Vehicle.Status.InRepair;
            var fordTransferSuccess = Ford.Transfer(Indy_101, Kok_101); // Should return false because only vehicles with a stand-by status can be transferred

            Assert.AreEqual(false, fordTransferSuccess);
        }

        [TestMethod]
        public void Transfer_Vehicle()
        {
            // Creating multiple vehicles
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "123456789012345678901234", Vehicle.Types.Truck);
            Vehicle Sienna = new Vehicle("Toyota", "Sienna", "2017", "432109876543210987654321", Vehicle.Types.Van);
            Vehicle Semi_1001 = new Vehicle("Mack", "Semi_1001", "2005", "134679134679134679134679", Vehicle.Types.Semis);
            Vehicle Semi_1002 = new Vehicle("Mack", "Semi_1002", "2006", "834679134679134679134679", Vehicle.Types.Semis);

            // Creating multiple distribution centers
            DistributionCenter Indy = new DistributionCenter("Indy");
            DistributionCenter Kokomo = new DistributionCenter("Kokomo");

            // Creating multiple branches
            Branch Indy_101 = new Branch("Indy_101");
            Branch Indy_202 = new Branch("Indy_202");
            Branch Kok_101 = new Branch("Kok_101");

            Indy_101.AddVehicle(Ford);
            Indy_202.AddVehicle(Sienna);

            var siennaTransferSuccess = Sienna.Transfer(Indy_202, Indy_101); // Should return true because this transfer is allowed: status of stand-by and both locations are branches

            Assert.AreEqual(true, siennaTransferSuccess);


        }


    }
}
