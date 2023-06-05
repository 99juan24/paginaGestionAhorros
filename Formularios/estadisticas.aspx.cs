using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace PaginaAhorro.Formularios
{
    public partial class estadisticas : System.Web.UI.Page
    {
        public ModeloAhorrosDataContext bd = new ModeloAhorrosDataContext();

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
            var ahorros = bd.ahorro.Where(a => a.fecha_creacion.Value.Month == mesActual).ToList();

            Ahorros = ahorros.Select(a => new AhorroData
            {
                Descripcion = a.descripcion,
                Monto = (double)a.monto,
                Progreso = (double)a.progreso,
                MesCreacion = a.fecha_creacion.Value.ToString("MMMM")
            }).ToList();
        }

        public class AhorroData
        {
            public string Descripcion { get; set; }
            public double Monto { get; set; }
            public double Progreso { get; set; }
            public string MesCreacion { get; set; }
        }



        public List<AhorroData> Ahorros { get; set; }

       
    }
}
