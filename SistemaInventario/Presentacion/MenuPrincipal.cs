using SistemaInventario.Presentacion.Inventario;
using SistemaInventario.Presentacion.Productos;
using SistemaInventario.Presentacion.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUInventario frmHIjo = new CUInventario();
            pnlOrigen.Controls.Clear();
            frmHIjo.Dock = DockStyle.Fill;
            pnlOrigen.Controls.Add(frmHIjo);
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUProductos frmHIjo = new CUProductos();
            pnlOrigen.Controls.Clear();
            frmHIjo.Dock = DockStyle.Fill;
            pnlOrigen.Controls.Add(frmHIjo);
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUProveedores frmHIjo = new CUProveedores();
            pnlOrigen.Controls.Clear();
            frmHIjo.Dock = DockStyle.Fill;
            pnlOrigen.Controls.Add(frmHIjo);
        }
    }
}
