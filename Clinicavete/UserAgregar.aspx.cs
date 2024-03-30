using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class UserAgregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
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
                // Verificar si el usuario ya existe en la base de datos
                if (UsuarioExiste(loginUsuario))
                {
                    MostrarMensajeError("El usuario ya existe.");
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AgregarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
                    cmd.Parameters.AddWithValue("@ClaveUsuario", claveUsuario);
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Mostrar mensaje de éxito
                MostrarMensajeExito("Usuario agregado correctamente.");
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MostrarMensajeError("Error al agregar usuario: " + ex.Message);
            }
        }

        // Método para verificar si el usuario ya existe en la base de datos
        private bool UsuarioExiste(string loginUsuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Usuarios WHERE LoginUsuario = @LoginUsuario";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
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

