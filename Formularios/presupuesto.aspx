<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="presupuesto.aspx.cs" Inherits="PaginaAhorro.Formularios.presupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container d-flex justify-content-center align-items-center " style="background-color:#9CCC65;"/>
    <div class="col-6">
    <div>
            <h1 style="color: white;">Formulario de Presupuesto</h1>

        <asp:Label ID="Label1" runat="server" Text="id:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" style="color: white;"></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;"/>

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"  style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;"/>
        


            <br />
            <br />
            <asp:GridView ID="gridPresupuesto" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

        
    </Columns>
</asp:GridView>
        <br /><br /><br /><br /><br /><br /><br />
        </div>
          </div>
    <br />
</asp:Content>
