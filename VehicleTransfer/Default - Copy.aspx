<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VehicleTransfer._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
            <asp:TextBox ID="txtVehicleMake" runat="server" Text="Enter vehicle make"></asp:TextBox>
            <asp:TextBox ID="txtVehicleModel" runat="server" Text="Enter vehicle model"></asp:TextBox>
            <asp:TextBox ID="txtVehicleYear" runat="server" Text="Enter vehicle year"></asp:TextBox>
            <asp:TextBox ID="txtVehicleVIN" runat="server" Text="Enter vehicle VIN"></asp:TextBox>
            <asp:Label ID="lblVehicleType" Text="Pick a vehicle type" runat="server"></asp:Label>
            <asp:DropDownList ID="ddVehicleType" runat="server"></asp:DropDownList>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
        <div class="row">
            <asp:Literal ID="litOutput" runat="server"></asp:Literal>
        </div>
    <div class="row">
        <asp:Label ID="lblVehicle" Text="Pick a vehicle" runat="server"></asp:Label>
            <asp:DropDownList ID="ddVehicle" runat="server"></asp:DropDownList>
    </div>
        

</asp:Content>
