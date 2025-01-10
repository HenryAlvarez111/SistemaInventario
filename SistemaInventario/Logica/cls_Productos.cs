using SistemaInventario.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Logica
{
    internal class cls_Productos
    {
        private Conexion conexion = new Conexion();

        public List<dto_Productos> Listar()
        {
            List<dto_Productos> lista = new List<dto_Productos>();
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Productos";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new dto_Productos
                    {
                        ProductoID = (int)reader["ProductoID"],
                        NombreProducto = reader["NombreProducto"].ToString(),
                        Precio = (decimal)reader["Precio"]
                    });
                }
            }
            return lista;
        }

        public void Insertar(dto_Productos producto)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"INSERT INTO Productos (NombreProducto, Precio) VALUES ('{producto.NombreProducto}', {producto.Precio})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(dto_Productos producto)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"UPDATE Productos SET NombreProducto = '{producto.NombreProducto}', Precio = {producto.Precio} WHERE ProductoID = {producto.ProductoID}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int productoID)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"DELETE FROM Productos WHERE ProductoID = {productoID}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
