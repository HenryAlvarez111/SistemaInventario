using SistemaInventario.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Logica
{
    internal class cls_Inventario
    {
        private Conexion conexion = new Conexion();

        public List<dto_Inventario> Listar()
        {
            List<dto_Inventario> lista = new List<dto_Inventario>();
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Inventarios";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new dto_Inventario
                    {
                        InventarioID = (int)reader["InventarioID"],
                        ProductoID = (int)reader["ProductoID"],
                        ProveedorID = (int)reader["ProveedorID"],
                        Cantidad = (int)reader["Cantidad"],
                        FechaIngreso = (DateTime)reader["FechaIngreso"],
                        Ubicacion = reader["Ubicacion"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Insertar(dto_Inventario inventario)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"INSERT INTO Inventarios (ProductoID, ProveedorID, Cantidad, FechaIngreso, Ubicacion) VALUES ({inventario.ProductoID}, {inventario.ProveedorID}, {inventario.Cantidad}, '{inventario.FechaIngreso:yyyy-MM-dd}', '{inventario.Ubicacion}')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(dto_Inventario inventario)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"UPDATE Inventarios SET ProductoID = {inventario.ProductoID}, ProveedorID = {inventario.ProveedorID}, Cantidad = {inventario.Cantidad}, FechaIngreso = '{inventario.FechaIngreso:yyyy-MM-dd}', Ubicacion = '{inventario.Ubicacion}' WHERE InventarioID = {inventario.InventarioID}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int inventarioID)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"DELETE FROM Inventarios WHERE InventarioID = {inventarioID}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
