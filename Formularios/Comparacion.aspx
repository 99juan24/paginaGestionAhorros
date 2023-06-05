<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/Principal.Master" AutoEventWireup="true" CodeBehind="Comparacion.aspx.cs" Inherits="PaginaAhorro.Formularios.Comparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Comparación Ahorros vs Gastos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <style type="text/css">
        .chart-container {
            width: 80%;
            margin: auto;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: #FDFEFE;">
        <h1 class="text-center">Comparación Ahorros vs Gastos</h1>
        <div class="chart-container">
            <canvas id="chart"></canvas>
        </div>
    </div>
    <script>
        window.onload = function () {
            var ctx = document.getElementById('chart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Ahorros', 'Gastos'],
                    datasets: [{
                        label: 'Monto',
                        data: [<%= ahorroMonto %>, <%= gastoMonto %>],
                        backgroundColor: [
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(255, 99, 132, 0.2)'
                        ],
                        borderColor: [
                            'rgba(75, 192, 192, 1)',
                            'rgba(255, 99, 132, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        };
    </script>
</asp:Content>
