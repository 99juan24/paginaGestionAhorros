<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="recordatorio.aspx.cs" Inherits="PaginaAhorro.Formularios.recordatorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container d-flex justify-content-center align-items-center " style="background-color:#9CCC65;"/>
    <div class="col-6">
      <div>
            <h1 style="color: white;">Recordatorios</h1>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
             <br /> 
            <br />
          <asp:Label ID="Label1" runat="server" Text="ID:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Nombre:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Descripcion:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCreationDate" runat="server" Text="fecha creacion:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtCreationDate" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDueDate" runat="server" Text="Fecha limite:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtDueDate" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSaveEvent" runat="server" Text="Save Event" OnClick="btnSaveEvent_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;"/>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;"/>

        </div>
    <br />
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
    </Columns>
</asp:GridView>

         <br />
    <br />
         <br />
    <br />

    </div>
          </div>
      </div>
</asp:Content>
