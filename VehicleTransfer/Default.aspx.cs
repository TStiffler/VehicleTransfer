using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleTransfer.Models;

namespace VehicleTransfer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //** With a UI, validation would likely need to be changed to return a specific message if there was an error *//
            //** Ex. "VIN has less than 24 characters".  Validation was kept basic because of time constraints.           *//

            // Create vehicles

            // Test valid VIN - ending VIN in a letter
            Vehicle Ford = new Vehicle("Ford", "F-150", "2018", "12345678901234567890123b", Vehicle.Types.Truck);
            string fordVIN = Ford.VIN; // fordVIN should be null because it was an invalid VIN

            litOutput.Text = "Added <br /> Make: Ford <br /> Model: F-150 <br /> Year: 2018 <br /> VIN: 12345678901234567890123b <br /> Type: Truck";
            litOutput.Text = litOutput.Text + "<br /> Results <br /> Make: " + Ford.make + " <br /> Model: " + Ford.model + "<br /> Year: " + Ford.year + "<br /> VIN: " + Ford.VIN;
            litOutput.Text = litOutput.Text + "<br /> VIN is blank because the last 5 digits must end in numeric values.";


            // Test valid VIN - VIN has less than 24 characters
            Ford = new Vehicle("Ford", "F-150", "2018", "12345678901234567890123", Vehicle.Types.Truck);
            fordVIN = Ford.VIN;  // fordVIN should be null because it had less than 24 characters

            litOutput.Text = litOutput.Text + "<br /><br />Added <br /> Make: Ford <br /> Model: F-150 <br /> Year: 2018 <br /> VIN: 12345678901234567890123 <br /> Type: Truck";
            litOutput.Text = litOutput.Text + "<br /> Results <br /> Make: " + Ford.make + " <br /> Model: " + Ford.model + "<br /> Year: " + Ford.year + "<br /> VIN: " + Ford.VIN + "<br /> Type: " + Ford.type;
            litOutput.Text = litOutput.Text + "<br /> VIN is blank because it was not 24 characters.";

            // Test valid year - Year is only two digits
            Ford = new Vehicle("Ford", "F-150", "18", "123456789012345678901234", Vehicle.Types.Truck);
            string fordYear = Ford.year; // fordYear should be null because it had less than 4 characters

            litOutput.Text = litOutput.Text + "<br /><br />Added <br /> Make: Ford <br /> Model: F-150 <br /> Year: 18 <br /> VIN: 123456789012345678901234 + <br /> Type: Truck";
            litOutput.Text = litOutput.Text + "<br /> Results <br /> Make: " + Ford.make + " <br /> Model: " + Ford.model + "<br /> Year: " + Ford.year + "<br /> VIN: " + Ford.VIN + "<br /> Type: " + Ford.type;
            litOutput.Text = litOutput.Text + "<br /> Year is blank because it was not 4 characters.";


            // Creating multiple vehicles
            Ford = new Vehicle("Ford", "F-150", "2018", "123456789012345678901234", Vehicle.Types.Truck);
            litOutput.Text = litOutput.Text + "<br /><br /> Added vehicle <br /> Make: " + Ford.make + " <br /> Model: " + Ford.model + "<br /> Year: " + Ford.year + "<br /> VIN: " + Ford.VIN + "<br /> Type: " + Ford.type;
            Vehicle Sienna = new Vehicle("Toyota", "Sienna", "2017", "432109876543210987654321", Vehicle.Types.Van);
            litOutput.Text = litOutput.Text + "<br /> Added vehicle <br /> Make: " + Sienna.make + " <br /> Model: " + Sienna.model + "<br /> Year: " + Sienna.year + "<br /> VIN: " + Sienna.VIN + "<br /> Type: " + Sienna.type;
            Vehicle Semi_1001 = new Vehicle("Mack", "Semi_1001", "2005", "134679134679134679134679", Vehicle.Types.Semis);
            litOutput.Text = litOutput.Text + "<br /> Added vehicle <br /> Make: " + Semi_1001.make + " <br /> Model: " + Semi_1001.model + "<br /> Year: " + Semi_1001.year + "<br /> VIN: " + Semi_1001.VIN + "<br /> Type: " + Semi_1001.type;
            Vehicle Semi_1002 = new Vehicle("Mack", "Semi_1002", "2006", "834679134679134679134679", Vehicle.Types.Semis);
            litOutput.Text = litOutput.Text + "<br /> Added vehicle <br /> Make: " + Semi_1002.make + " <br /> Model: " + Semi_1002.model + "<br /> Year: " + Semi_1002.year + "<br /> VIN: " + Semi_1002.VIN + "<br /> Type: " + Semi_1002.type;

            // Creating multiple distribution centers
            DistributionCenter Indy = new DistributionCenter("Indy");
            litOutput.Text = litOutput.Text + "<br /><br /> Created distribution center named " + Indy.name;
            DistributionCenter Kokomo = new DistributionCenter("Kokomo");
            litOutput.Text = litOutput.Text + "<br /> Created distribution center named " + Kokomo.name;


            // Creating multiple branches
            Branch Indy_101 = new Branch("Indy_101");
            litOutput.Text = litOutput.Text + "<br /><br /> Created branch named " + Indy_101.name;
            Branch Indy_202 = new Branch("Indy_202");
            litOutput.Text = litOutput.Text + "<br /> Created branch named " + Indy_202.name;
            Branch Kok_101 = new Branch("Kok_101");
            litOutput.Text = litOutput.Text + "<br /> Created branch named " + Kok_101.name;

            // Add branches to Distribution Centers
            Indy.AddBranch(Indy_101);
            litOutput.Text = litOutput.Text + "<br /><br /> Added branch to distribution center <br /> Distribution Center: " + Indy.name + " <br /> Branches: " + Indy.branches.FirstOrDefault();
            Indy.AddBranch(Kok_101);
            litOutput.Text = litOutput.Text + "<br /> Added branch to distribution center <br /> Distribution Center: " + Kokomo.name + " <br /> Branches: " + Kokomo.branches.FirstOrDefault();

            // Add semis to distribution centers
            Indy.AddVehicle(Semi_1001);
            litOutput.Text = litOutput.Text + "<br /><br /> Added vehicle to distribution center <br /> Distribution Center: " + Indy.name + " <br /> Vehicles: " + Indy.vehicles.FirstOrDefault();
            Kokomo.AddVehicle(Semi_1002);
            litOutput.Text = litOutput.Text + "<br /> Added vehicle to distribution center <br /> Distribution Center: " + Kokomo.name + " <br /> Vehicles: " + Kokomo.vehicles.FirstOrDefault();

            // Add vehicles to branches
            Indy_101.AddVehicle(Ford);
            litOutput.Text = litOutput.Text + "<br /><br /> Added vehicle to branch <br /> Branch: " + Indy_101.name + " <br /> Vehicles: " + Indy_101.vehicles.FirstOrDefault();
            Indy_202.AddVehicle(Sienna);
            litOutput.Text = litOutput.Text + "<br /> Added vehicle to branch <br /> Branch: " + Indy_202.name + " <br /> Vehicles: " + Indy_202.vehicles.FirstOrDefault();

            // Test - Try to transfer semi to a branch
            var semiTransferSuccess = Semi_1001.Transfer(Indy, Indy_101); // Should return false because a semi cannot be transferred to a branch
            litOutput.Text = litOutput.Text + "<br /><br /> Tried to transfer semi from a branch to a distribution center <br /> Result: " + semiTransferSuccess.ToString();
            litOutput.Text = litOutput.Text + "<br /> Transfer failed because a semi cannot be transferred to a branch.";


            // Test - Change a vehicle status and try to transfer
            Ford.status = Vehicle.Status.InRepair;
            var fordTransferSuccess = Ford.Transfer(Indy_101, Kok_101); // Should return false because only vehicles with a stand-by status can be transferred
            litOutput.Text = litOutput.Text + "<br /><br /> Tried to transfer a vehicle with a status of In Repair <br /> Result: " + fordTransferSuccess.ToString();
            litOutput.Text = litOutput.Text + "<br /> Transfer failed because a vehicle must have a status of stand-by to be transferred.";

            // Test - Transfer a vehicle
            var siennaTransferSuccess = Sienna.Transfer(Indy_202, Indy_101); // Should return true because this transfer is allowed: status of stand-by and both locations are branches
            litOutput.Text = litOutput.Text + "<br /><br /> Tried to transfer a van between branches <br /> Result: " + siennaTransferSuccess.ToString();
            litOutput.Text = litOutput.Text + "<br /> Transfer succeeded.";

        }
    }
}