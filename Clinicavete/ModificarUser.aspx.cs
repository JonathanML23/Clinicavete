using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class ModificarUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string loginUsuario = txtLoginUsuario.Text.Trim();
            string claveUsuario = txtClaveUsuario.Text.Trim();
            string nombreUsuario = txtNombreUsuario.Text.Trim();

            // Validación de entrada de datos
            if (string.IsNullOrEmpty(loginUsuario) || string.IsNullOrEmpty(claveUsuario) || string.IsNullOrEmpty(nombreUsuario))
            {
                MostrarMensajeError("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
                    cmd.Parameters.AddWithValue("@ClaveUsuario", claveUsuario);
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Mostrar mensaje de éxito
                MostrarMensajeExito("Usuario modificado correctamente.");
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MostrarMensajeError("Error al modificar usuario: " + ex.Message);
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

