using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer.Server;
using System.Web.UI.WebControls;

namespace Clinicavete
{
    public partial class reporteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Crear el comando para llamar al procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("ObtenerUsuarios", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Crear el adaptador de datos y el DataSet
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    // Abrir la conexión y llenar el DataSet con los datos del procedimiento almacenado
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
            Response.Redirect("UserAgregar.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarUser.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarUser.aspx");
        }
    }
}

