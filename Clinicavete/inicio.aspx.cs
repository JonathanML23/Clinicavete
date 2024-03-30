using System;
using System.Web.UI;

namespace Clinicavete
{
    public partial class inicioaspx : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si el usuario está logueado
                if (Session["Usuario"] != null)
                {
                    // Mostrar el cuadro con el nombre de usuario
                    userBox.Visible = true;
                    lblUsuario.Text = Session["Usuario"].ToString();

                    // Mostrar el menú de reportes
                    menu.Visible = true;
                }
                else
                {
                    // Ocultar el menú de reportes si el usuario no está logueado
                    menu.Visible = false;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de login (Login.aspx)
            Response.Redirect("Login.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de registro (Registro.aspx)
            Response.Redirect("Registro.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Limpiar la sesión y redirigir a la página de inicio (inicio.aspx)
            Session.Clear();
            Response.Redirect("inicio.aspx");
        }
    }
}
