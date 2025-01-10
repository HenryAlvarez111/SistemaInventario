using SistemaInventario.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Logica
{
    internal class cls_Proveedor
    {
        private Conexion conexion = new Conexion();

        public List<dto_Proveedor> Listar()
        {
            List<dto_Proveedor> lista = new List<dto_Proveedor>();
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = "SELECT * FROM Proveedores";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new dto_Proveedor
                    {
                        ProveedorID = (int)reader["ProveedorID"],
                        NombreProveedor = reader["NombreProveedor"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        RUC = reader["RUC"].ToString()
                    });
                }
            }
            return lista;
        }

        public void Insertar(dto_Proveedor proveedor)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"INSERT INTO Proveedores (NombreProveedor, Direccion, Telefono, RUC) VALUES ('{proveedor.NombreProveedor}', '{proveedor.Direccion}', '{proveedor.Telefono}', '{proveedor.RUC}')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(dto_Proveedor proveedor)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"UPDATE Proveedores SET NombreProveedor = '{proveedor.NombreProveedor}', Direccion = '{proveedor.Direccion}', Telefono = '{proveedor.Telefono}', RUC = '{proveedor.RUC}' WHERE ProveedorID = {proveedor.ProveedorID}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int proveedorID)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                string query = $"DELETE FROM Proveedores WHERE ProveedorID = {proveedorID}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
