using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinicavete
{
    public partial class AgregarMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
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
                    SqlCommand cmd = new SqlCommand("AgregarMascota", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreMascota", nombreMascota);
                    cmd.Parameters.AddWithValue("@TipoMascota", tipoMascota);
                    cmd.Parameters.AddWithValue("@ComidaFavorita", comidaFavorita);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Mostrar mensaje de éxito
                        MostrarMensajeExito("Mascota agregada correctamente.");
                    }
                    else
                    {
                        // Mostrar mensaje de error
                        MostrarMensajeError("No se pudo agregar la mascota. Es posible que ya exista en la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MostrarMensajeError("Error al agregar mascota: " + ex.Message);
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

