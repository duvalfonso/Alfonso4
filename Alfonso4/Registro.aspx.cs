using Alfonso4.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Alfonso4
{
  public partial class Registro : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
        CargarDataGridTodos();
      }
    }

    private void LimpiarCampos()
    {
      txtRut.Text = string.Empty;
      txtNombre.Text = string.Empty;
      txtNota1.Text = string.Empty;
      txtNota2.Text = string.Empty;
      txtNota3.Text = string.Empty;
      txtRut.Focus();
    }

    private void CargarDataGridPorBusqueda()
    {
      string busqueda = "%" + txtBuscar.Text.Trim() + "%";
      string query = @"SELECT * FROM alumnos WHERE nombre LIKE @nombre OR rut like @rut";
      dgvAlumnos.DataSource = Metodos.Consulta(query, new SqlParameter("@nombre", busqueda), new SqlParameter("@rut", busqueda));
      dgvAlumnos.DataBind();
    }

    private void CargarDataGridTodos()
    {
      string query = "SELECT * FROM alumnos";
      dgvAlumnos.DataSource = Metodos.Consulta(query);
      dgvAlumnos.DataBind();
    }

    private void AgregarAlumno()
    {
      try
      {
        using(SqlConnection conn = Conexion.Conectar())
        {
          conn.Open();
          string rut = txtRut.Text;
          string nombre = txtNombre.Text;
          double n1 = double.Parse(txtNota1.Text, CultureInfo.InvariantCulture);
          double n2 = double.Parse(txtNota2.Text, CultureInfo.InvariantCulture);
          double n3 = double.Parse(txtNota3.Text, CultureInfo.InvariantCulture);
          double promedio = Math.Round((n1 + n2 + n3) / 3, 1);
          string query = "INSERT INTO alumnos (rut, nombre, nota1, nota2, nota3, promedio) " +
            "VALUES (@rut, @nombre, @n1, @n2, @n3, @promedio)";
          SqlCommand cmd = new SqlCommand(query, conn);
          cmd.Parameters.AddWithValue("@rut", rut);
          cmd.Parameters.AddWithValue("@nombre", nombre);
          cmd.Parameters.AddWithValue("@n1", n1);
          cmd.Parameters.AddWithValue("@n2", n2);
          cmd.Parameters.AddWithValue("@n3", n3);
          cmd.Parameters.AddWithValue("@promedio", promedio);
          cmd.ExecuteNonQuery();

          Metodos.ControlarAlerta(alertaIngreso, "success", "Se ha registrado un alumno nuevo con éxito");
          LimpiarCampos();
          CargarDataGridTodos();
        }

      }
      catch (SqlException ex) when (ex.Number == 2627)
      {
        Metodos.ControlarAlerta(alertaIngreso, "danger", "El RUT ingresado ya existe en la base de datos, por favor verificar.");
        txtRut.Focus();
      }
      catch (Exception ex)
      {
        Metodos.ControlarAlerta(alertaIngreso, "danger", "Error inesperado: " + ex.Message);
      }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
      if(
        string.IsNullOrWhiteSpace(txtRut.Text)
        || string.IsNullOrWhiteSpace(txtNombre.Text)
        || string.IsNullOrWhiteSpace(txtNota1.Text)
        || string.IsNullOrWhiteSpace(txtNota2.Text)
        || string.IsNullOrWhiteSpace(txtNota3.Text)
        )
      {
        alertaIngreso.Attributes["class"] = "alert alert-danger alert-dismissible fade show mb-0";
        textoAlerta.InnerText = "Campos incompletos!";
        return;
      }

      AgregarAlumno();

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
      CargarDataGridPorBusqueda();
    }

    protected void btnBuscarTodos_Click(object sender, EventArgs e)
    {
      CargarDataGridTodos();
    }
  }
}