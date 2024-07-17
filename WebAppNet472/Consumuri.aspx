<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/AdminAssociationMaster.Master" AutoEventWireup="true" CodeBehind="Consumuri.aspx.cs" Inherits="WebAppNet472.Consumuri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Consumuri</title>
    <style>
        .editable-field {
            background-color: #f0f8ff; /* Light blue background for editable fields */
            border: 1px solid #ccc; /* Light gray border for better visibility */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>Consumuri declarate</h3>
    </div>
    <div>
        <div class="form-group inline">
            <label class="control-label">Scara</label>
            <asp:DropDownList ID="ddlScara" runat="server"
                CssClass="form-control col-md-6"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlScara_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="well" style="background-color: antiquewhite">
            <asp:Label ID="lbl1" runat="server" CssClass="control-label" Font-Size="X-Large">Total persoane:</asp:Label>
            <asp:Label ID="lblNrPersTotal" runat="server" CssClass="control-label" Font-Size="X-Large" ForeColor="Green"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="control-label" Font-Size="X-Large">Total consum AR:</asp:Label>
            <asp:Label ID="lblConsumARTotal" runat="server" CssClass="control-label" Font-Size="X-Large" ForeColor="Green"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" CssClass="control-label" Font-Size="X-Large">Total consum ACM:</asp:Label>
            <asp:Label ID="lblConsumACMTotal" runat="server" CssClass="control-label" Font-Size="X-Large" ForeColor="Green"></asp:Label>


        </div>

        <div>
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
        </div>
        <asp:GridView ID="gvApartamente" AutoGenerateColumns="false"
            runat="server"
            CssClass="table" DataKeyNames="idApart"
            OnRowEditing="gvApartamente_RowEditing"
            OnRowCancelingEdit="gvApartamente_RowCancelingEdit"
            OnRowUpdating="gvApartamente_RowUpdating">
            <Columns>
                <asp:BoundField ReadOnly="true" DataField="Nr" HeaderText="Nr. apt." />
               
                <asp:BoundField ControlStyle-Width="40px" DataField="Nrpers" ControlStyle-CssClass="editable-field " HeaderText="Nr. pers." />

                <asp:BoundField ControlStyle-Width="40px" DataField="ConsumAR" ControlStyle-CssClass="editable-field " HeaderText="Apa Rece" />
                <asp:BoundField ControlStyle-Width="40px" DataField="ConsumACM" ControlStyle-CssClass="editable-field " HeaderText="Apa Calda" />
                
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
