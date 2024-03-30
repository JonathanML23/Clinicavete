using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class reportemascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Crear el comando para obtener los datos de las mascotas
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Mascotas", con);

                    // Crear el adaptador de datos y el DataSet
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    // Abrir la conexión y llenar el DataSet con los datos de las mascotas
                    con.Open();
                    adapter.Fill(ds);

                    // Enlazar el GridView con el DataSet
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMascota.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarMascota.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarMascota.aspx");
        }
    }
}
