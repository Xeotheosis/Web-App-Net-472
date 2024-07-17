<%@ Page Title="" Language="C#" Async="true"  MasterPageFile="~/Cheltuieli.Master" AutoEventWireup="true" CodeBehind="ApaPluviala.aspx.cs" Inherits="WebAppNet472.ApaPluviala" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
     .editable-field {
         background-color: #f0f8ff; /* Light blue background for editable fields */
         border: 1px solid #ccc; /* Light gray border for better visibility */
     }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
          <div class="container">
      <h3>Apa pluviala</h3>
      <div class="well" style="background-color: antiquewhite">
          <asp:Label ID="lbl1" runat="server" CssClass="control-label" Font-Size="X-Large">Total facturi:</asp:Label>
          <asp:Label ID="lblTotal" runat="server" CssClass="control-label" Font-Size="X-Large" ForeColor="Green"></asp:Label>
      </div>
      <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
      <asp:GridView ID="gvFact"
          runat="server"
          CssClass="table table-condensed"
          DataKeyNames="idScara"
          AutoGenerateColumns="false" 
          OnRowEditing="gvFact_RowEditing"  
          OnRowCancelingEdit="gvFact_RowCancelingEdit"   
          OnRowUpdating="gvFact_RowUpdating"   >
          <Columns>
               
              
              <asp:BoundField HeaderText="Scara" DataField="NumeScara" ReadOnly="true" />
              <asp:BoundField HeaderText="Valoare" DataField="cpp2asoc" ControlStyle-CssClass="editable-field "/>
              <asp:CommandField ShowEditButton="True" />
          </Columns>

      </asp:GridView>
  </div>
</asp:Content>
