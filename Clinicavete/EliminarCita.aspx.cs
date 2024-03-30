using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Clinicavete
{
    public partial class EliminarCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Puedes agregar código adicional de inicialización aquí si es necesario
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID de la cita a eliminar
                int idCita;
                if (!int.TryParse(txtIDCita.Text, out idCita))
                {
                    lblError.Text = "El ID de la cita debe ser un número entero.";
                    lblError.Visible = true;
                    return;
                }

                // Llamar al método para eliminar la cita
                if (EliminarCitaDB(idCita))
                {
                    lblMessage.Text = "La cita se ha eliminado correctamente.";
                    lblMessage.Visible = true;
                }
                else
                {
                    lblError.Text = "No se pudo eliminar la cita. Por favor, verifica el ID de la cita.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al intentar eliminar la cita. Detalles: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private bool EliminarCitaDB(int idCita)
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

            // Consulta SQL para eliminar la cita
            string query = "DELETE FROM Citas WHERE ID_Cita = @ID_Cita";

            // Crear la conexión
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Crear el comando
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Agregar parámetro para el ID de la cita
                    cmd.Parameters.AddWithValue("@ID_Cita", idCita);

                    // Abrir la conexión
                    con.Open();

                    // Ejecutar la consulta y verificar si se eliminó correctamente
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}

