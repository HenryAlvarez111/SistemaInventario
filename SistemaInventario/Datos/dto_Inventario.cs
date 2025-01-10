using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Datos
{
    internal class dto_Inventario
    {
        public int InventarioID { get; set; }
        public int ProductoID { get; set; }
        public int ProveedorID { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Ubicacion { get; set; }
    }
}
