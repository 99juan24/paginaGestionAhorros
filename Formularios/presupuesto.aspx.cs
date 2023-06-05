using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace PaginaAhorro.Formularios
{
    public partial class presupuesto : System.Web.UI.Page
    {
        readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los datos del presupuesto existentes en el GridView
                CargarPresupuestos();
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            string nombre = txtNombre.Text;
            decimal cantidad = Convert.ToDecimal(txtCantidad.Text);

            // Guardar el presupuesto en la base de datos
            GuardarPresupuesto(id, nombre, cantidad);

            // Limpiar los campos de entrada
            txtid.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            // Volver a cargar los datos del presupuesto en el GridView
            CargarPresupuestos();

            // Actualizar el valor del presupuesto en la página maestra
            if (Master is Principal masterPage)
            {
                decimal totalPresupuesto = ObtenerTotalPresupuesto();
                masterPage.ActualizarValorPresupuesto(totalPresupuesto);
            }
        }

        private void GuardarPresupuesto(int id,string nombre, decimal cantidad)
        {
            // Establecer la cadena de conexión con tu base de datos
           

            // Query SQL para insertar el presupuesto en la base de datos
            string query = "INSERT INTO presupuesto (Id,Nombre, Cantidad) VALUES (@id,@nombre, @cantidad)";

            // Crear la conexión y el comando SQL
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);

                // Agregar los parámetros a la consulta SQL
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@cantidad", cantidad);

                // Abrir la conexión y ejecutar el comando
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }

        private decimal ObtenerTotalPresupuesto()
        {
            // Establecer la cadena de conexión con tu base de datos
           

            // Query SQL para obtener la suma total de los presupuestos
            string query = "SELECT SUM(Cantidad) FROM presupuesto";

            // Crear la conexión y el comando SQL
            using (SqlConnection  conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);

                // Abrir la conexión y ejecutar el comando
                conexion.Open();
                var totalPresupuesto = (decimal)command.ExecuteScalar();
                conexion.Close();

                return totalPresupuesto;
            }
        }


        private void CargarPresupuestos()
        {
            // Establecer la cadena de conexión con tu base de datos
          

            // Query SQL para obtener los presupuestos de la base de datos
            string query = "SELECT * FROM presupuesto";

            // Crear la conexión y el adaptador de datos
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);

                // Crear un DataSet para almacenar los datos del presupuesto
                DataSet dataSet = new DataSet();

                // Llenar el DataSet con los datos del presupuesto
                adapter.Fill(dataSet);

                // Asignar el DataSet como fuente de datos del GridView
                gridPresupuesto.DataSource = dataSet.Tables[0];
                gridPresupuesto.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el identificador del presupuesto a eliminar
            int id = int.Parse(txtid.Text);

            // Eliminar el presupuesto de la base de datos
            EliminarPresupuesto(id);

            // Limpiar los campos de entrada
            txtid.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            // Volver a cargar los datos del presupuesto en el GridView
            CargarPresupuestos();

            // Actualizar el valor del presupuesto en la página maestra
            if (Master is Principal masterPage)
            {
                decimal totalPresupuesto = ObtenerTotalPresupuesto();
                masterPage.ActualizarValorPresupuesto(totalPresupuesto);
            }
        }
        private void EliminarPresupuesto(int id)
        {
            // Query SQL para eliminar el presupuesto de la base de datos
            string query = "DELETE FROM presupuesto WHERE Id = @id";

            // Crear la conexión y el comando SQL
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conexion);

                // Agregar el parámetro a la consulta SQL
                command.Parameters.AddWithValue("@id", id);

                // Abrir la conexión y ejecutar el comando
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el identificador del presupuesto a buscar
            int id = int.Parse(txtid.Text);

            // Buscar el presupuesto en la base de datos
            DataTable presupuesto = BuscarPresupuesto(id);

            // Verificar si se encontró el presupuesto
            if (presupuesto.Rows.Count > 0)
            {
                // Mostrar los datos del presupuesto en los TextBox
                txtid.Text = presupuesto.Rows[0]["ID"].ToString();
                txtNombre.Text = presupuesto.Rows[0]["Nombre"].ToString();
                txtCantidad.Text = presupuesto.Rows[0]["Cantidad"].ToString();
            }
            else
            {
                // Limpiar los TextBox si no se encontró el presupuesto
                txtid.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtCantidad.Text = string.Empty;

                // Mostrar un mensaje de error o realizar alguna acción adicional
                // Puedes agregar un control Label en tu formulario para mostrar mensajes de error
                // lblMensaje.Text = "Presupuesto no encontrado";
            }
        }

        private DataTable BuscarPresupuesto(int id)
        {
            // Query SQL para buscar el presupuesto por ID
            string query = "SELECT * FROM presupuesto WHERE ID = @id";

            // Crear la conexión y el adaptador de datos
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);

                // Crear un DataTable para almacenar los datos del presupuesto
                DataTable dataTable = new DataTable();

                // Llenar el DataTable con los datos del presupuesto
                adapter.Fill(dataTable);

                return dataTable;
            }
        }






    }
}