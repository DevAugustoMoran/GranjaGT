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
    public partial class frmEnvios : Form
    {
        CDenvios cd_envios = new CDenvios();
        CLenvios cl_envios = new CLenvios();

        public frmEnvios()
        {
            InitializeComponent();
        }

        private void frmEnvios_Load(object sender, EventArgs e)
        {
            MtdMostrarListaVenta();
            MtdMostrarListaEmpleados();
            MtdConsultarEnvios();
            lblFecha.Text = cl_envios.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void MtdMostrarListaVenta()
        {
            var ListaVentas = cd_envios.MtdListarVentas();

            foreach (var Ventas in ListaVentas)
            {
                cboxCodigoVenta.Items.Add(Ventas);
            }

            cboxCodigoVenta.DisplayMember = "Text";
            cboxCodigoVenta.ValueMember = "Value";
        }

        private void MtdMostrarListaEmpleados()
        {
            var ListaEmpleados = cd_envios.MtdListarEmpleados();

            foreach (var Empleados in ListaEmpleados)
            {
                cboxCodigoEmpleado.Items.Add(Empleados);
            }

            cboxCodigoEmpleado.DisplayMember = "Text";
            cboxCodigoEmpleado.ValueMember = "Value";
        }

        private void MtdConsultarEnvios()
        {
            DataTable dtEnvios = cd_envios.MtdConsultarEnvios();
            dgvEnvios.DataSource = dtEnvios;
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoEnvio.Text = "";
            cboxCodigoVenta.Text = "";
            cboxCodigoEmpleado.Text = "";
            dtpFechaEnvio.Value = DateTime.Now;
            txtDireccionEnvio.Text = "";
            cboxTipoTransporte.Text = "";
            txtPlacaTransporte.Text = "";
            txtObservacion.Text = "";
            cboxEstado.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboxCodigoVenta.Text == "" || cboxCodigoEmpleado.Text == "" || txtDireccionEnvio.Text == "" || cboxTipoTransporte.Text == "" ||
                txtPlacaTransporte.Text == "" || txtObservacion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());
                    int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                    DateTime FechaEnvio = dtpFechaEnvio.Value;
                    string DireccionEnvio = txtDireccionEnvio.Text;
                    string TipoTransporte = cboxTipoTransporte.Text;
                    string PlacaTransporte = txtPlacaTransporte.Text;
                    string Observacion = txtObservacion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                    DateTime FechaAuditoria = cl_envios.MtdFechaActual();

                    cd_envios.MtdAgregarEnvios(CodigoVenta, CodigoEmpleado, FechaEnvio, DireccionEnvio, TipoTransporte, PlacaTransporte, Observacion, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Envío agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarEnvios();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboxCodigoVenta.Text == "" || cboxCodigoEmpleado.Text == "" || txtDireccionEnvio.Text == "" || cboxTipoTransporte.Text == "" ||
                txtPlacaTransporte.Text == "" || txtObservacion.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoEnvio = int.Parse(txtCodigoEnvio.Text);
                    int CodigoVenta = int.Parse(cboxCodigoVenta.Text.Split('-')[0].Trim());
                    int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                    DateTime FechaEnvio = dtpFechaEnvio.Value;
                    string DireccionEnvio = txtDireccionEnvio.Text;
                    string TipoTransporte = cboxTipoTransporte.Text;
                    string PlacaTransporte = txtPlacaTransporte.Text;
                    string Observacion = txtObservacion.Text;
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                    DateTime FechaAuditoria = cl_envios.MtdFechaActual();

                    cd_envios.MtdActualizarEnvios(CodigoEnvio, CodigoVenta, CodigoEmpleado, FechaEnvio, DireccionEnvio, TipoTransporte, PlacaTransporte, Observacion, Estado, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Envío actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarEnvios();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int CodigoEnvio = int.Parse(txtCodigoEnvio.Text);

            cd_envios.MtdEliminarEnvios(CodigoEnvio);
            MessageBox.Show("Envio eliminado correctamente", "Eliminar envío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdConsultarEnvios();
            MtdLimpiarCampos();
        }

        private void dgvEnvios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoEnvio.Text = dgvEnvios.SelectedCells[0].Value.ToString();
            cboxCodigoVenta.Text = dgvEnvios.SelectedCells[1].Value.ToString();
            cboxCodigoEmpleado.Text = dgvEnvios.SelectedCells[2].Value.ToString();
            dtpFechaEnvio.Text = dgvEnvios.SelectedCells[3].Value.ToString();
            txtDireccionEnvio.Text = dgvEnvios.SelectedCells[4].Value.ToString();
            cboxTipoTransporte.Text = dgvEnvios.SelectedCells[5].Value.ToString();
            txtPlacaTransporte.Text = dgvEnvios.SelectedCells[6].Value.ToString();
            txtObservacion.Text = dgvEnvios.SelectedCells[7].Value.ToString();
            cboxEstado.Text = dgvEnvios.SelectedCells[8].Value.ToString();
        }
    }
}
