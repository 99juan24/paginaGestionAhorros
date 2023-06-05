<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="Gasto.aspx.cs" Inherits="PaginaAhorro.Formularios.Gasto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    MIS GASTOS
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        font-weight: bold;
        font-size: medium;
    }
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center " style="background-color:#9CCC65;"/>
    <div class="col-6">
        <br />
        <br />
        <div class="modal-title align-content-center h3">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label runat="server" Text=" MIS GASTOS" Font-Size="Larger" style="color: white;"></asp:Label>
         </div>
        <br />
        <br />
      <div class="align-items-center col-auto">
    <asp:Panel ID="Panel1" runat="server"  Width="493px">
        <asp:Label ID="Label6" runat="server" Text="Id del gasto: " style="color: white;" ></asp:Label>        
        <asp:TextBox ID="txtid" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nombre Gasto: " style="color: white;" ></asp:Label>        
        <asp:TextBox ID="txtnombre" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Monto del gasto:" style="color: white;" ></asp:Label>
        <asp:TextBox ID="txtmonto" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Progresol gasto:" style="color: white;" ></asp:Label>
        <asp:TextBox ID="txtprogreso" runat="server" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Fecha creacion:" style="color: white;"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txtfechacreacion" runat="server" TextMode="Date" Width="274px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Fecha limite:" style="color: white;"></asp:Label>
         &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="txfechalimite" runat="server" TextMode="Date" Width="274px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;"/>
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar"  style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
        <asp:Button ID="btnModificar" runat="server"  OnClick="btnModificar_Click"  Text="Modificar"  style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" style="background-color: #f44336; color: white; padding: 10px 20px; border: none; border-radius: 4px; font-size: 16px;" />
        <br />
        <br />
    </asp:Panel>
          <br />
           <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Información gastos" CssClass="auto-style1"></asp:Label>
          <br /> 
    <asp:GridView ID="DatosGastos" runat="server" CellPadding="4" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
        <br />
        <br />
        <br />


          </div></div>
    
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Sitio_Web_Full_Produccion.Formularios.ModeloProductosDataContext" EntityTypeName="" Select="new (Id, nombre, monto, fecha_creacion,fecha_limite,progreso,estado)" TableName="gasto" OnSelecting="LinqDataSource1_Selecting"></asp:LinqDataSource>
</asp:Content>
