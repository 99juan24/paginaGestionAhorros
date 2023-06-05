<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="estadisticas_gastos.aspx.cs" Inherits="PaginaAhorro.Formularios.estadisticas_gastos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ESTADÍSTICAS
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Ahorro');
            data.addColumn('number', 'Monto');
            data.addColumn('number', 'Progreso');

            <% foreach (var gasto in Gastos) { %>
            data.addRow(['<%= gasto.Descripcion %>', <%= gasto.Monto %>, <%= gasto.Progreso %>]);
            <% } %>

            var options = {
                title: 'Comparación entre Monto y Progreso de Gastos',
                hAxis: { title: 'Gastos' },
                vAxis: { title: 'Valor' },
                seriesType: 'bars',
                series: { 1: { type: 'line' } },
                colors: ['#4bc0c0', '#CD6155']
            };

            var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h2>Estadísticas de Gastos</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <div id="chart_div" style="width: 100%; height: 400px;"></div>
            </div>
        </div>
    </div>
</asp:Content>