﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Datos
{
    internal class dto_Proveedor
    {
        public int ProveedorID { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string RUC { get; set; }
    }
}
