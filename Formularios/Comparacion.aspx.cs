using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaAhorro.Formularios
{
    public partial class Comparacion : System.Web.UI.Page
    {
        public ModeloAhorrosDataContext bd = new ModeloAhorrosDataContext();
        public ModeloGastosDataContext bdg = new ModeloGastosDataContext();
        public decimal ahorroMonto;
        public decimal gastoMonto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        protected void CargarDatos()
        {
            var ahorros = bd.ahorro.Select(a => a.monto).ToList();
            var gastos = bdg.gasto.Select(g => g.monto).ToList();

            if (ahorros.Any())
            {
                ahorroMonto = (decimal)ahorros.Sum();
            }

            if (gastos.Any())
            {
                gastoMonto = (decimal)gastos.Sum();
            }
        }
    }
}