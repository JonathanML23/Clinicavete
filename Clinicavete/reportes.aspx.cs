using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Clinicavete
{
    public partial class reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    ComboBoxReportes.Visible = true;
                    ButtonSalir.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void ComboBoxReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoReporte = ComboBoxReportes.SelectedValue;

            switch (tipoReporte)
            {
                case "UsuariosRegistrados":
                    GenerarReporteUsuariosRegistrados();
                    break;
                case "UsuariosActivosInactivos":
                    GenerarReporteUsuariosActivosInactivos();
                    break;
                case "UsuariosPorFechaRegistro":
                    GenerarReporteUsuariosPorFechaRegistro();
                    break;
                case "TodosUsuarios":
                    GenerarReporteTodosUsuarios();
                    break;
                default:
                    MostrarMensaje("Error", "Seleccione un tipo de reporte válido.");
                    break;
            }
        }


        private void GenerarReporteUsuariosRegistrados()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;
            string storedProcedure = "ObtenerUsuariosRegistrados";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        GridViewReporte.DataSource = reader;
                        GridViewReporte.DataBind();
                        GridViewReporte.Visible = true;
                    }
                    else
                    {
                        MostrarMensaje("Información", "No se encontraron usuarios registrados.");
                        GridViewReporte.Visible = false;
                    }
                }
            }
        }

        private void GenerarReporteUsuariosActivosInactivos()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;
            string storedProcedure = "ObtenerUsuariosActivosInactivos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        GridViewReporte.DataSource = reader;
                        GridViewReporte.DataBind();
                        GridViewReporte.Visible = true;
                    }
                    else
                    {
                        MostrarMensaje("Información", "No se encontraron usuarios activos/inactivos.");
                        GridViewReporte.Visible = false;
                    }
                }
            }
        }

        private void GenerarReporteUsuariosPorFechaRegistro()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;
            string storedProcedure = "ObtenerUsuariosPorFechaRegistro";

            // Definir las fechas de inicio y fin
            DateTime fechaInicio = DateTime.Parse("1900-01-01");
            DateTime fechaFin = DateTime.Now; // O cualquier otra fecha que desees como fecha final

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros '@FechaInicio' y '@FechaFin'
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        GridViewReporte.DataSource = reader;
                        GridViewReporte.DataBind();
                        GridViewReporte.Visible = true;
                    }
                    else
                    {
                        // Manejar caso donde no se encontraron usuarios en el rango de fechas especificado
                    }
                }
            }
        }

        private void GenerarReporteTodosUsuarios()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TuCadenaDeConexion"].ConnectionString;
            string storedProcedure = "ObtenerTodosUsuarios";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        GridViewReporte.DataSource = reader;
                        GridViewReporte.DataBind();
                        GridViewReporte.Visible = true;
                    }
                    else
                    {
                        MostrarMensaje("Información", "No se encontraron usuarios.");
                        GridViewReporte.Visible = false;
                    }
                }
            }
        }
        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
        private void MostrarMensaje(string titulo, string mensaje)
        {
            // Lógica para mostrar un mensaje al usuario
        }
    }
}