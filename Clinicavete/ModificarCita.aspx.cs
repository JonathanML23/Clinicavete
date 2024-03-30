using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Clinicavete
{
    public partial class ModificarCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar las mascotas en el DropDownList al cargar la página por primera vez
                CargarMascotas();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar la entrada de datos
                if (!ValidarEntrada())
                {
                    return;
                }

                // Obtener los valores ingresados por el usuario
                int idCita = Convert.ToInt32(txtIDCita.Text);
                int idMascota = Convert.ToInt32(ddlMascota.SelectedValue);
                DateTime fecha = Convert.ToDateTime(txtFecha.Text);
                string medico = txtMedico.Text;

                // Obtener la cadena de conexión desde el archivo Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                // Crear una nueva conexión SQL
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Crear un nuevo comando SQL para ejecutar el stored procedure ModificarCita
                    using (SqlCommand cmd = new SqlCommand("ModificarCita", con))
                    {
                        // Especificar el tipo de comando como stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros al comando
                        cmd.Parameters.AddWithValue("@ID_Cita", idCita);
                        cmd.Parameters.AddWithValue("@ID_Mascota", idMascota);
                        cmd.Parameters.AddWithValue("@Proxima_fecha", fecha);
                        cmd.Parameters.AddWithValue("@Medico_Asignado", medico);

                        // Abrir la conexión
                        con.Open();

                        // Ejecutar el comando y obtener el número de filas afectadas
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Cerrar la conexión
                        con.Close();

                        // Verificar si se modificó correctamente y mostrar el mensaje correspondiente
                        if (rowsAffected > 0)
                        {
                            MostrarExito("La cita se ha modificado correctamente.");
                        }
                        else
                        {
                            MostrarError("No se pudo modificar la cita. Por favor, revise los datos e inténtelo de nuevo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de excepción
                MostrarError("Error: " + ex.Message);
            }
        }

        // Método para validar la entrada de datos
        private bool ValidarEntrada()
        {
            int idCita;
            if (!int.TryParse(txtIDCita.Text, out idCita))
            {
                MostrarError("El ID de la cita debe ser un número entero.");
                return false;
            }

            DateTime fecha;
            if (!DateTime.TryParse(txtFecha.Text, out fecha))
            {
                MostrarError("Ingrese una fecha válida en el formato correcto.");
                return false;
            }

            return true;
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

        // Método para cargar las mascotas en el DropDownList
        private void CargarMascotas()
        {
            try
            {
                // Obtener la cadena de conexión desde el archivo Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;

                // Crear una nueva conexión SQL
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Crear un nuevo comando SQL para seleccionar las mascotas
                    using (SqlCommand cmd = new SqlCommand("SELECT ID_Mascota, Nombre_Mascota FROM Mascotas", con))
                    {
                        // Abrir la conexión
                        con.Open();

                        // Crear un nuevo adaptador de datos para leer los resultados
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            // Crear un nuevo DataTable para almacenar los resultados
                            DataTable dt = new DataTable();

                            // Llenar el DataTable con los datos del adaptador
                            adapter.Fill(dt);

                            // Asignar el DataTable como origen de datos para el DropDownList
                            ddlMascota.DataSource = dt;
                            ddlMascota.DataTextField = "Nombre_Mascota";
                            ddlMascota.DataValueField = "ID_Mascota";
                            ddlMascota.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de excepción
                MostrarError("Error al cargar las mascotas: " + ex.Message);
            }
        }
    }
}

