using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class reportecitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de agregar citas
            Response.Redirect("AgregarCita.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de modificar citas
            Response.Redirect("ModificarCita.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Redireccionar a la página de eliminar citas
            Response.Redirect("EliminarCita.aspx");
        }

        private void BindGrid()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT C.ID_Cita, M.Nombre_Mascota, C.Proxima_fecha, C.Medico_Asignado FROM Citas C INNER JOIN Mascotas M ON C.ID_Mascota = M.ID_Mascota", con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}

