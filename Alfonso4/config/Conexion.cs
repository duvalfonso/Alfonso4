using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Alfonso4.config
{
  public class Conexion
  {
    public static SqlConnection Conectar()
    {
      string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
        @"AttachDbFilename=|DataDirectory|\Prueba4.mdf;" +
        @"Integrated Security=True";
      SqlConnection conn = new SqlConnection(connectionString);
      return conn;
    }
  }
}