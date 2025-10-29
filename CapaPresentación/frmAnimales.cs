using CapaDatos;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentación
{
    public partial class frmAnimales: Form
    {
        CDanimales cdanimales = new CDanimales();
        CLanimales clanimales = new CLanimales();

        public frmAnimales()
        {
            InitializeComponent();
        }

        public void mtdConsultarAnimales()
        {
            DataTable dtanimales = cdanimales.MtdConsultarAnimales();
            dgvAnimales.DataSource = dtanimales;
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoAnimal.Text = "";
            txtTipoAnimal.Text = "";
            txtRaza.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtPrecio.Text = "";
            txtDescripcion.Text = "";
            cboxEstado.Text = "";
        }

        private void frmAnimales_Load(object sender, EventArgs e)
        {
            lblFecha.Text = clanimales.MtdFechaActual().ToString("dd/MM/yyyy");
            mtdConsultarAnimales();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTipoAnimal.Text == "" || txtRaza.Text == "" || txtPrecio.Text == "" || txtDescripcion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string TipoAnimal = txtTipoAnimal.Text;
                    string Raza = txtRaza.Text;
                    DateTime FechaNacimiento = dtpFechaNacimiento.Value;
                    decimal Precio = Convert.ToDecimal(txtPrecio.Text);
                    string Descripcion = txtDescripcion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clanimales.MtdFechaActual();
                    cdanimales.MtdAgregarAnimal(TipoAnimal, Raza, FechaNacimiento, Precio, Descripcion, Estado, UsuarioAuditoria, FechaAuditoria.ToString());
                    MessageBox.Show("Animal agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarAnimales();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAnimales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoAnimal.Text = dgvAnimales.SelectedCells[0].Value.ToString();
            txtTipoAnimal.Text = dgvAnimales.SelectedCells[1].Value.ToString();
            txtRaza.Text = dgvAnimales.SelectedCells[2].Value.ToString();
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvAnimales.SelectedCells[3].Value);
            txtPrecio.Text = dgvAnimales.SelectedCells[4].Value.ToString();
            txtDescripcion.Text = dgvAnimales.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvAnimales.SelectedCells[6].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigoAnimal.Text == "" || txtTipoAnimal.Text == "" || txtRaza.Text == "" || txtPrecio.Text == "" || txtDescripcion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor seleccione un animal para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoAnimal = Convert.ToInt32(txtCodigoAnimal.Text);
                    string TipoAnimal = txtTipoAnimal.Text;
                    string Raza = txtRaza.Text;
                    DateTime FechaNacimiento = dtpFechaNacimiento.Value;
                    decimal Precio = Convert.ToDecimal(txtPrecio.Text);
                    string Descripcion = txtDescripcion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Administrador";
                    DateTime FechaAuditoria = clanimales.MtdFechaActual();
                    cdanimales.MtdActualizarAnimal(CodigoAnimal, TipoAnimal, Raza, FechaNacimiento, Precio, Descripcion, Estado, UsuarioAuditoria, FechaAuditoria.ToString());
                    MessageBox.Show("Animal actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarAnimales();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoAnimal.Text == "")
            {
                MessageBox.Show("Por favor seleccione un animal para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoAnimal = Convert.ToInt32(txtCodigoAnimal.Text);
                    cdanimales.MtdEliminarAnimal(CodigoAnimal);
                    MessageBox.Show("Animal eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdConsultarAnimales();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
