using SistemaInventario.Datos;
using SistemaInventario.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventario.Presentacion.Productos
{
    public partial class CUProductos : UserControl
    {
        private cls_Productos clsProductos = new cls_Productos();
        private dto_Productos productoSeleccionado = null;
        public CUProductos()
        {
            InitializeComponent(); CargarDatos();
        }
        private void CargarDatos()
        {
            dgvInformacion.DataSource = clsProductos.Listar();
            dgvInformacion.ClearSelection();
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            productoSeleccionado = null;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }
        private void CUProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dto_Productos nuevoProducto = new dto_Productos
            {
                NombreProducto = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text)
            };

            clsProductos.Insertar(nuevoProducto);
            MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }

        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                productoSeleccionado = new dto_Productos
                {
                    ProductoID = int.Parse(dgvInformacion.Rows[e.RowIndex].Cells["ProductoID"].Value.ToString()),
                    NombreProducto = dgvInformacion.Rows[e.RowIndex].Cells["NombreProducto"].Value.ToString(),
                    Precio = decimal.Parse(dgvInformacion.Rows[e.RowIndex].Cells["Precio"].Value.ToString())
                };

                txtNombre.Text = productoSeleccionado.NombreProducto;
                txtPrecio.Text = productoSeleccionado.Precio.ToString();

                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado == null || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, seleccione un producto válido y complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            productoSeleccionado.NombreProducto = txtNombre.Text;
            productoSeleccionado.Precio = decimal.Parse(txtPrecio.Text);

            clsProductos.Actualizar(productoSeleccionado);
            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }
    }
}
