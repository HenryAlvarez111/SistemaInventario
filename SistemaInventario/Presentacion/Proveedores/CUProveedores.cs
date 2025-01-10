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

namespace SistemaInventario.Presentacion.Proveedores
{
    public partial class CUProveedores : UserControl
    {
        private cls_Proveedor clsProveedor = new cls_Proveedor();
        private dto_Proveedor proveedorSeleccionado = null;
        public CUProveedores()
        {
            InitializeComponent(); CargarDatos();
        }
        private void CargarDatos()
        {
            dgvInformacion.DataSource = clsProveedor.Listar();
            dgvInformacion.ClearSelection();
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelf.Clear();
            txtRUC.Clear();
            proveedorSeleccionado = null;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }
        private void CUProveedores_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) ||
            string.IsNullOrWhiteSpace(txtTelf.Text) || string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dto_Proveedor nuevoProveedor = new dto_Proveedor
            {
                NombreProveedor = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelf.Text,
                RUC = txtRUC.Text
            };

            clsProveedor.Insertar(nuevoProveedor);
            MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }

        private void dgvInformacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                proveedorSeleccionado = new dto_Proveedor
                {
                    ProveedorID = int.Parse(dgvInformacion.Rows[e.RowIndex].Cells["ProveedorID"].Value.ToString()),
                    NombreProveedor = dgvInformacion.Rows[e.RowIndex].Cells["NombreProveedor"].Value.ToString(),
                    Direccion = dgvInformacion.Rows[e.RowIndex].Cells["Direccion"].Value.ToString(),
                    Telefono = dgvInformacion.Rows[e.RowIndex].Cells["Telefono"].Value.ToString(),
                    RUC = dgvInformacion.Rows[e.RowIndex].Cells["RUC"].Value.ToString()
                };

                txtNombre.Text = proveedorSeleccionado.NombreProveedor;
                txtDireccion.Text = proveedorSeleccionado.Direccion;
                txtTelf.Text = proveedorSeleccionado.Telefono;
                txtRUC.Text = proveedorSeleccionado.RUC;

                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionado == null || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) ||
            string.IsNullOrWhiteSpace(txtTelf.Text) || string.IsNullOrWhiteSpace(txtRUC.Text))
            {
                MessageBox.Show("Por favor, seleccione un proveedor válido y complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            proveedorSeleccionado.NombreProveedor = txtNombre.Text;
            proveedorSeleccionado.Direccion = txtDireccion.Text;
            proveedorSeleccionado.Telefono = txtTelf.Text;
            proveedorSeleccionado.RUC = txtRUC.Text;

            clsProveedor.Actualizar(proveedorSeleccionado);
            MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }
    }
}
