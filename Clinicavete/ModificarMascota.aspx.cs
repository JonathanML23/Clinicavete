using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class ModificarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int idMascota;
            if (!int.TryParse(txtIDMascota.Text, out idMascota))
            {
                MostrarMensajeError("El ID de la mascota debe ser un número entero.");
                return;
            }

            string nombreMascota = txtNombreMascota.Text.Trim();
            string tipoMascota = txtTipoMascota.Text.Trim();
            string comidaFavorita = txtComidaFavorita.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(nombreMascota) || string.IsNullOrEmpty(tipoMascota) || string.IsNullOrEmpty(comidaFavorita))
                {
                    MostrarMensajeError("Por favor, complete todos los campos.");
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ModificarMascota", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDMascota", idMascota);
                    cmd.Parameters.AddWithValue("@NombreMascota", nombreMascota);
                    cmd.Parameters.AddWithValue("@TipoMascota", tipoMascota);
                    cmd.Parameters.AddWithValue("@ComidaFavorita", comidaFavorita);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Mostrar mensaje de éxito
                        MostrarMensajeExito("Mascota modificada correctamente.");
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
                MostrarMensajeError("Error al modificar mascota: " + ex.Message);
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

