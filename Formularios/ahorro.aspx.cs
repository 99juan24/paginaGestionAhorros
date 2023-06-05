using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaAhorro.Formularios
{
    public partial class ahorro1 : System.Web.UI.Page
    {
        public ModeloAhorrosDataContext bd = new ModeloAhorrosDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEliminar.Attributes.Add("Onclick", "return confirm('Desea eliminar el registro ? ')");
                btnGuardar.Attributes.Add("Onclick", "return alert('Registro guardado...')");
                btnModificar.Attributes.Add("Onclick", "return alert('Registro modificado...')");
                carga();
            }

        }
        public void carga()
        {
            DatosAhorro.DataBind();
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            var misdatos = from registros in bd.ahorro select registros;
            e.Arguments.TotalRowCount = misdatos.Count();
            e.Result = misdatos;

        }
        public void limpiar()
        {
            txtid.Text = "";
            txtnombre.Text = "";
            txtmonto.Text = "";
            txtprogreso.Text = "";
            txtfechacreacion.Text = "";
            txfechalimite.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtid.Text);
                String nombre = txtnombre.Text;
                float cantidad = float.Parse(txtmonto.Text);
                float progreso = float.Parse(txtprogreso.Text);
                DateTime fecha_creacion = DateTime.Parse(txtfechacreacion.Text);
                DateTime fecha_limite = DateTime.Parse(txfechalimite.Text);
                decimal progresoDecimal = decimal.Parse(progreso.ToString());
                ((Principal)this.Master).ActualizarPresupuesto(progresoDecimal);
                bd.insertarAhorros(codigo, nombre, cantidad, progreso, fecha_creacion, fecha_limite);
                
                carga();
                limpiar();
            }
            catch (Exception ex)
            {
                Response.Write("<script language='JavaScript'>alert('Error en la información...!!!');</script>");
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtid.Text);
                int cuentaregistros = 0;
                var registro = bd.buscarAhorros(codigo);
                foreach (var campo in registro)
                {
                    txtnombre.Text = campo.descripcion;
                    txtmonto.Text = campo.monto.ToString();
                    txtfechacreacion.Text = campo.fecha_creacion.ToString();
                    txfechalimite.Text = campo.fecha_limite.ToString();

                    cuentaregistros = 1;
                }
                if (cuentaregistros == 0)
                {
                    Response.Write("<script>alert('id no Existe...!!!');</script>");
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error en la información...!!!');</script>");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtid.Text);
                bd.eliminarAhorros(codigo);
                carga();
                limpiar();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error en la información...!!!');</script>");
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(txtid.Text);
                String nombre = txtnombre.Text;
                float cantidad = float.Parse(txtmonto.Text);
                float progreso = float.Parse(txtprogreso.Text);
                DateTime fecha_limite = DateTime.Parse(txfechalimite.Text);
                decimal progresoDecimal = decimal.Parse(progreso.ToString());
                ((Principal)this.Master).ActualizarPresupuesto(progresoDecimal);
                string estado = "En progreso";
                if (progreso == cantidad)
                {
                    estado = "Completado";
                    // Mostrar mensaje al usuario
                    Response.Write("<script>alert('¡Has logrado tu meta de ahorro! Puedes eliminarlo si lo deseas.');</script>");

                    // Mostrar botón para eliminar el gasto
                    btnEliminar.Visible = true;
                }

                bd.actualizarAhorro(codigo, nombre, cantidad, progreso, fecha_limite, estado);
                carga();
                limpiar();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error en la información...!!!');</script>");
            }
        }
    }
}