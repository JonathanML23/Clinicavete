using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Clinicavete
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string username = Request.Form["username"];
                string password = Request.Form["password"];

                if (string.IsNullOrEmpty(password))
                {
                    MostrarError("Por favor, ingresa una contraseña.");
                    return;
                }

                if (!UsuarioExistente(username))
                {
                    if (RegistrarUsuario(username, password))
                    {
                        MostrarExito("¡Usuario registrado exitosamente!");
                    }
                    else
                    {
                        MostrarError("Error al registrar al usuario. Por favor, intenta nuevamente.");
                    }
                }
                else
                {
                    MostrarError("El nombre de usuario ya está en uso. Por favor, elige otro.");
                }
            }
        }

        private bool UsuarioExistente(string nombreUsuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;
            string query = "EXEC ObtenerUsuarioPorNombre @NombreUsuario";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int count = Convert.ToInt32(result);
                            return count > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Ocurrió un error durante la verificación del usuario. Por favor, intenta nuevamente.");
                Console.WriteLine("Error al verificar usuario existente: " + ex.Message);
            }

            return false; // Retornar false en caso de error o resultado nulo
        }

        private bool RegistrarUsuario(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "EXEC CrearUsuario @LoginUsuario, @ClaveUsuario, @NombreUsuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoginUsuario", username);
                        command.Parameters.AddWithValue("@ClaveUsuario", password);
                        command.Parameters.AddWithValue("@NombreUsuario", username); // Puedes ajustar este valor según tus necesidades
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Ocurrió un error durante el registro. Por favor, intenta nuevamente más tarde.");
                Console.WriteLine("Error al registrar al usuario: " + ex.Message);
                return false;
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }

        private void MostrarExito(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.ForeColor = System.Drawing.Color.Green; // Color verde para indicar éxito
            lblError.Visible = true;
        }
    }
}