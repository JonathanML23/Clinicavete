using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class EliminarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMascota;
            if (!int.TryParse(txtIDMascota.Text, out idMascota))
            {
                MostrarMensajeError("El ID de la mascota debe ser un número entero.");
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("EliminarMascota", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDMascota", idMascota);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Mostrar mensaje de éxito
                        MostrarMensajeExito("Mascota eliminada correctamente.");
                    }
                    else
                    {
                        // Mostrar mensaje de error si no se encontró la mascota
                        MostrarMensajeError("No se encontró la mascota con el ID especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MostrarMensajeError("Error al eliminar mascota: " + ex.Message);
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
