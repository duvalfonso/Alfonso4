using Alfonso4.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Alfonso4
{
  public class Metodos
  {
    public static DataTable Consulta(string query, params SqlParameter[] parametros)
    {
      try
      {
        using (SqlConnection conn = Conexion.Conectar())
        {
          conn.Open();
          DataTable dt = new DataTable();
          SqlCommand cmd = new SqlCommand(query, conn);

          foreach (SqlParameter param in parametros)
          {
            cmd.Parameters.Add(param);
          }

          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          adapter.Fill(dt);
          return dt;
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Error en la consulta: " + ex.Message);
      }
    }

    public static void ControlarAlerta(HtmlGenericControl alertaControl, string tipo, string mensaje)
    {
      if (alertaControl == null) return;

      alertaControl.Attributes["class"] = $"alert alert-{tipo} alert-dismissible fade show mb-0";
      foreach (var control in alertaControl.Controls)
      {
        if (control is HtmlGenericControl span && span.TagName.ToLower() == "span")
        {
          span.InnerText = mensaje;
          break;
        }
      }
    }


  }
}
