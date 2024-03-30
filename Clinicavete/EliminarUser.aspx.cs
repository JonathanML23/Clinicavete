using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class EliminarUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string loginUsuario = txtLoginUsuario.Text.Trim();

            // Validación de entrada de datos
            if (string.IsNullOrEmpty(loginUsuario))
            {
                MostrarMensajeError("Por favor, ingrese el login del usuario.");
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoginUsuario", loginUsuario);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Mostrar mensaje de éxito
                MostrarMensajeExito("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MostrarMensajeError("Error al eliminar usuario: " + ex.Message);
            }
        }

        // Método para mostrar mensaje de éxito
        private void MostrarMensajeExito(string mensaje)
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            lblError.Visible = false;
        }

        // Método para mostrar mensaje de error
        private void MostrarMensajeError(string mensaje)
        {
            lblError.Visible = true;
            lblError.Text = mensaje;
            lblMensaje.Visible = false;
        }
    }
}

