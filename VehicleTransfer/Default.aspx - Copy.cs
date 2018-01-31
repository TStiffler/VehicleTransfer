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
            if (!IsPostBack)
            {
                ViewState["vehicles"] = new List<Vehicle>();

                Array itemValues = System.Enum.GetValues(typeof(Vehicle.Types));
                Array itemNames = System.Enum.GetNames(typeof(Vehicle.Types));

                for (int i = 0; i <= itemNames.Length - 1; i++)
                {
                    ListItem item = new ListItem(itemValues.GetValue(i).ToString(), itemValues.GetValue(i).ToString());
                    ddVehicleType.Items.Add(item);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Vehicle.Types type = new Vehicle.Types();

            Enum.TryParse(ddVehicleType.Text, out type);

            Vehicle newVehicle = new Vehicle(txtVehicleMake.Text, txtVehicleModel.Text, txtVehicleYear.Text, txtVehicleVIN.Text, type);
            var vehicles = (List<Vehicle>)ViewState["vehicles"];
            vehicles.Add(newVehicle);

            ddVehicle.Items.Clear();
            litOutput.Text = "";
            foreach (Vehicle v in vehicles)
            {
                litOutput.Text = litOutput.Text + v.make + ", " + v.model + ", " + v.year + ", " + v.VIN + ", " + v.type + "<br />";

                ListItem itemVehicle = new ListItem(v.VIN, v.VIN);
                ddVehicle.Items.Add(itemVehicle);
            }
        }
    }
}