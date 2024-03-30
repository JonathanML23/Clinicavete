using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Clinicavete
{
    public partial class Login : Page
    {
        // Define la cadena de conexión
        string connectionString = "Data Source=MINI-CEBOLLITA\\JONATHAN;Initial Catalog=Veterinaria;Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Limpia los mensajes al cargar la página
            lblMensaje.Text = "";

            // Verificar si hay una sesión activa
            if (Session["Usuario"] != null)
            {
                // Mostrar el cuadro con el nombre de usuario y el botón de cerrar sesión
                userBox.Visible = true;
                lblUsuario.InnerText = Session["Usuario"].ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtener las credenciales ingresadas por el usuario
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validar las credenciales
            if (ValidarCredenciales(username, password))
            {
                // Autenticación exitosa, guardar el nombre de usuario en la sesión
                Session["Usuario"] = username;

                // Redirigir a la página de inicio con indicación de inicio de sesión exitoso
                Response.Redirect("inicio.aspx?loginSuccess=true");
            }
            else
            {
                // Mostrar mensaje de error si las credenciales son incorrectas
                lblMensaje.Text = "Usuario o contraseña incorrectos. Por favor, inténtalo de nuevo.";
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Limpiar la sesión y redirigir a la página de inicio
            Session.Clear();
            Response.Redirect("inicio.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de registro
            Response.Redirect("Registro.aspx");
        }

        private bool ValidarCredenciales(string username, string password)
        {
            // Consulta SQL para validar las credenciales
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Login_Usuario = @Username AND Clave_Usuario = @Password";

            // Crear y abrir la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Crear el comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros para el nombre de usuario y la contraseña
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // Ejecutar la consulta y obtener el resultado
                    int count = (int)command.ExecuteScalar();

                    // Devolver true si las credenciales son válidas
                    return count > 0;
                }
            }
        }
    }
}