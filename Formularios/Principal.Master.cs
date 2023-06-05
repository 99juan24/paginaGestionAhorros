using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaAhorro.Formularios
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                int id = int.Parse(Session["usuariologueado"].ToString());
                SqlCommand comando = new SqlCommand("Perfil", conexion);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                leer.Read();
                this.lblusuario.Text = leer["Apellidos"].ToString() + " , " + leer["Nombres"].ToString();
                ImgPerfil.ImageUrl = "/Formularios/FrmImagen.aspx?id=" + id;
                conexion.Close();
                if (!IsPostBack)
                {
                    // Obtener el valor actualizado del presupuesto
                    decimal totalPresupuesto = ObtenerTotalPresupuesto();

                    // Actualizar el texto del Label
                    lblValorPresupuesto.Text = totalPresupuesto.ToString("C");
                }


            }
            else
            {
                Response.Redirect("/Formulario/Login.aspx");
            }

        }
        protected void Perfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Formularios/Perfil.aspx");
        }
        protected void Salir_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("/Formularios/Login.aspx");
        }

        public void ActualizarValorPresupuesto(decimal totalPresupuesto)
        {
            lblValorPresupuesto.Text = totalPresupuesto.ToString("C");
        }

        private decimal ObtenerTotalPresupuesto()
        {
            decimal total = 0;

            // Establecer la cadena de conexión con tu base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString;

            // Query SQL para obtener el valor total del presupuesto
            string query = "SELECT SUM(Cantidad) FROM presupuesto";

            // Crear la conexión y el comando SQL
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);

                // Abrir la conexión y ejecutar el comando
                conexion.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    total = Convert.ToDecimal(result);
                }

                conexion.Close();
            }

            return total;
        }
        public void ActualizarPresupuesto(decimal monto)
        {
            decimal presupuestoActual = ObtenerTotalPresupuesto();
            decimal presupuestoRestante = presupuestoActual - monto;

            // Actualizar el valor del presupuesto
            ActualizarValorPresupuesto(presupuestoRestante);

            // Verificar si el presupuesto restante es menor a 300,000
            if (presupuestoRestante < 300000)
            {
                // Generar la alerta
                ScriptManager.RegisterStartupScript(this, GetType(), "PresupuestoAlerta", "alert('¡Atención! El presupuesto está por agotarse.');", true);
            }
        }




    }
}