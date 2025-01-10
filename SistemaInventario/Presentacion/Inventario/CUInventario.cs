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

namespace SistemaInventario.Presentacion.Inventario
{
    public partial class CUInventario : UserControl
    {
        private cls_Inventario clsInventario = new cls_Inventario();
        private cls_Productos clsProductos = new cls_Productos();
        private cls_Proveedor clsProveedores = new cls_Proveedor();
        private dto_Inventario inventarioSeleccionado = null;
        public CUInventario()
        {
            InitializeComponent(); CargarDatos();
            CargarCombobox();
        }
        private void CargarDatos()
        {
            dgvInformacion.DataSource = clsInventario.Listar();
            dgvInformacion.ClearSelection();
            LimpiarControles();
        }

        private void CargarCombobox()
        {
            cmbProducto.DataSource = clsProductos.Listar();
            cmbProducto.DisplayMember = "NombreProducto";
            cmbProducto.ValueMember = "ProductoID";

            cmbProveedor.DataSource = clsProveedores.Listar();
            cmbProveedor.DisplayMember = "NombreProveedor";
            cmbProveedor.ValueMember = "ProveedorID";
        }

        private void LimpiarControles()
        {
            cmbProducto.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            txtCantidad.Clear();
            dtpFecha.Value = DateTime.Now;
            txtUbicacion.Clear();
            inventarioSeleccionado = null;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }
        private void CUInventario_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1 || cmbProveedor.SelectedIndex == -1 ||
            string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dto_Inventario nuevoInventario = new dto_Inventario
            {
                ProductoID = (int)cmbProducto.SelectedValue,
                ProveedorID = (int)cmbProveedor.SelectedValue,
                Cantidad = int.Parse(txtCantidad.Text),
                FechaIngreso = dtpFecha.Value,
                Ubicacion = txtUbicacion.Text
            };

            clsInventario.Insertar(nuevoInventario);
            MessageBox.Show("Inventario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (inventarioSeleccionado == null || cmbProducto.SelectedIndex == -1 || cmbProveedor.SelectedIndex == -1 ||
            string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Por favor, seleccione un inventario válido y complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            inventarioSeleccionado.ProductoID = (int)cmbProducto.SelectedValue;
            inventarioSeleccionado.ProveedorID = (int)cmbProveedor.SelectedValue;
            inventarioSeleccionado.Cantidad = int.Parse(txtCantidad.Text);
            inventarioSeleccionado.FechaIngreso = dtpFecha.Value;
            inventarioSeleccionado.Ubicacion = txtUbicacion.Text;

            clsInventario.Actualizar(inventarioSeleccionado);
            MessageBox.Show("Inventario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }

        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                inventarioSeleccionado = new dto_Inventario
                {
                    InventarioID = int.Parse(dgvInformacion.Rows[e.RowIndex].Cells["InventarioID"].Value.ToString()),
                    ProductoID = int.Parse(dgvInformacion.Rows[e.RowIndex].Cells["ProductoID"].Value.ToString()),
                    ProveedorID = int.Parse(dgvInformacion.Rows[e.RowIndex].Cells["ProveedorID"].Value.ToString()),
                    Cantidad = int.Parse(dgvInformacion.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString()),
                    FechaIngreso = DateTime.Parse(dgvInformacion.Rows[e.RowIndex].Cells["FechaIngreso"].Value.ToString()),
                    Ubicacion = dgvInformacion.Rows[e.RowIndex].Cells["Ubicacion"].Value.ToString()
                };

                cmbProducto.SelectedValue = inventarioSeleccionado.ProductoID;
                cmbProveedor.SelectedValue = inventarioSeleccionado.ProveedorID;
                txtCantidad.Text = inventarioSeleccionado.Cantidad.ToString();
                dtpFecha.Value = inventarioSeleccionado.FechaIngreso;
                txtUbicacion.Text = inventarioSeleccionado.Ubicacion;

                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }
    }
}
