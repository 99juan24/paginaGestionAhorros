using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaAhorro.Formularios
{
    public partial class estadisticas_gastos : System.Web.UI.Page
    {
        public ModeloGastosDataContext bd = new ModeloGastosDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            // Obtener el mes actual
            int mesActual = DateTime.Now.Month;

            // Filtrar los ahorros por el mes de creación
            var gastos = bd.gasto.Where(a => a.fecha_creacion.Value.Month == mesActual).ToList();

            Gastos = gastos.Select(a => new GastoData
            {
                Descripcion = a.nombre,
                Monto = (double)a.monto,
                Progreso = (double)a.progreso,
                MesCreacion = a.fecha_creacion.Value.ToString("MMMM")
            }).ToList();
        }

        public class GastoData
        {
            public string Descripcion { get; set; }
            public double Monto { get; set; }
            public double Progreso { get; set; }
            public string MesCreacion { get; set; }
        }



        public List<GastoData> Gastos { get; set; }


    }
}