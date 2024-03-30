using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class AgregarCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMascotas();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idMascota;
                if (!int.TryParse(ddlMascota.SelectedValue, out idMascota))
                {
                    MostrarError("Seleccione una mascota válida.");
                    return;
                }

                DateTime fecha;
                if (!DateTime.TryParse(txtFecha.Text, out fecha))
                {
                    MostrarError("Ingrese una fecha válida en el formato correcto.");
                    return;
                }

                string medico = txtMedico.Text;

                // Validar que la fecha de la cita no esté en el pasado
                if (fecha < DateTime.Today)
                {
                    MostrarError("La fecha de la cita no puede ser en el pasado.");
                    return;
                }

                // Verificar si ya existe una cita para la mascota en la fecha especificada
                if (ExisteCita(idMascota, fecha))
                {
                    MostrarError("Ya existe una cita para esta mascota en la fecha especificada.");
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AgregarCita", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Mascota", idMascota);
                    cmd.Parameters.AddWithValue("@Proxima_fecha", fecha);
                    cmd.Parameters.AddWithValue("@Medico_Asignado", medico);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MostrarExito("La cita se ha guardado correctamente.");
            }
            catch (Exception ex)
            {
                MostrarError("Error al guardar la cita: " + ex.Message);
            }
        }

        // Método para cargar las mascotas en el DropDownList
        private void CargarMascotas()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT ID_Mascota, Nombre_Mascota FROM Mascotas", con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ddlMascota.DataSource = dt;
                    ddlMascota.DataTextField = "Nombre_Mascota";
                    ddlMascota.DataValueField = "ID_Mascota";
                    ddlMascota.DataBind();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar las mascotas: " + ex.Message);
            }
        }

        // Método para verificar si ya existe una cita para la mascota en la fecha especificada
        private bool ExisteCita(int idMascota, DateTime fecha)
        {
            bool existe = false;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Citas WHERE ID_Mascota = @ID_Mascota AND Proxima_fecha = @Proxima_fecha", con);
                    cmd.Parameters.AddWithValue("@ID_Mascota", idMascota);
                    cmd.Parameters.AddWithValue("@Proxima_fecha", fecha);

                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    existe = (count > 0);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al verificar la existencia de la cita: " + ex.Message);
            }
            return existe;
        }

        // Método para mostrar mensaje de éxito
        private void MostrarExito(string mensaje)
        {
            lblMessage.Visible = true;
            lblMessage.Text = mensaje;
            lblError.Visible = false;
        }

        // Método para mostrar mensaje de error
        private void MostrarError(string mensaje)
        {
            lblError.Visible = true;
            lblError.Text = mensaje;
            lblMessage.Visible = false;
        }
    }
}
