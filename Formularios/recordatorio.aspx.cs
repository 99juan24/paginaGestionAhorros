using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaAhorro.Formularios
{
    public partial class recordatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Realiza acciones adicionales al cargar la página
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;

            // Mostrar eventos existentes en la fecha seleccionada
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre, descripcion FROM recordatorio WHERE fecha_limite = @FechaLimite";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FechaLimite", selectedDate);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    reader.Close();
                }
            }
        }


        protected void btnSaveEvent_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            string name = txtName.Text;
            string description = txtDescription.Text;
            DateTime creationDate = Convert.ToDateTime(txtCreationDate.Text);
            DateTime dueDate = Convert.ToDateTime(txtDueDate.Text);

            // Guarda el evento en la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO recordatorio (Id,nombre, descripcion, fecha_creacion, fecha_limite) VALUES (@Id,@Nombre, @Descripcion, @FechaCreacion, @FechaLimite)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", name);
                    cmd.Parameters.AddWithValue("@Descripcion", description);
                    cmd.Parameters.AddWithValue("@FechaCreacion", creationDate);
                    cmd.Parameters.AddWithValue("@FechaLimite", dueDate);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Realiza acciones adicionales después de guardar el evento
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);

            // Realizar la búsqueda del recordatorio en la base de datos y cargar los datos en los campos de entrada
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre, descripcion, fecha_creacion, fecha_limite FROM recordatorio WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["nombre"].ToString();
                        txtDescription.Text = reader["descripcion"].ToString();
                        txtCreationDate.Text = reader["fecha_creacion"].ToString();
                        txtDueDate.Text = reader["fecha_limite"].ToString();
                    }
                    else
                    {
                        // El recordatorio no fue encontrado, puedes mostrar un mensaje de error o realizar otra acción
                    }
                    reader.Close();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            string name = txtName.Text;
            string description = txtDescription.Text;
            DateTime creationDate = Convert.ToDateTime(txtCreationDate.Text);
            DateTime dueDate = Convert.ToDateTime(txtDueDate.Text);

            // Actualizar el recordatorio en la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE recordatorio SET nombre = @Nombre, descripcion = @Descripcion, fecha_creacion = @FechaCreacion, fecha_limite = @FechaLimite WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", name);
                    cmd.Parameters.AddWithValue("@Descripcion", description);
                    cmd.Parameters.AddWithValue("@FechaCreacion", creationDate);
                    cmd.Parameters.AddWithValue("@FechaLimite", dueDate);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // El recordatorio se actualizó correctamente, puedes realizar una acción adicional o mostrar un mensaje de éxito
                    }
                    else
                    {
                        // No se encontró el recordatorio para actualizar, puedes mostrar un mensaje de error o realizar otra acción
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);

            // Eliminar el recordatorio de la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM recordatorio WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // El recordatorio se eliminó correctamente, puedes realizar una acción adicional o mostrar un mensaje de éxito
                    }
                    else
                    {
                        // No se encontró el recordatorio para eliminar, puedes mostrar un mensaje de error o realizar otra acción
                    }
                }
            }
        }

    }
}