using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Datos
{
    internal class Conexion
    {
        private readonly string connectionString;

        public Conexion()
        {
            connectionString = "Server=.;Database=SistemaInventario;User Id=sa;Password=123456;";
        }

        public SqlConnection AbrirConexion()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open(); 
            return connection;
        }
    }
}
