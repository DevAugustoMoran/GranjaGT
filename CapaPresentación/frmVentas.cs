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
    public partial class frmVentas: Form
    {
        CDventas cd_ventas = new CDventas();
        CLventas cl_ventas = new CLventas();

        public frmVentas()
        {
            InitializeComponent();
        }

        //LLENAR COMBOBOX CON LISTAS
        private void MtdMostrarListaClientes()
        {
            var ListaClientes = cd_ventas.MtdListarClientes();

            foreach (var Clientes in ListaClientes)
            {
                cboxCodigoCliente.Items.Add(Clientes);
            }

            cboxCodigoCliente.DisplayMember = "Text";
            cboxCodigoCliente.ValueMember = "Value";
        }
        private void MtdMostrarListaGranjas()
        {
            var ListaGranjas = cd_ventas.MtdListarGranjas();
            foreach (var Granjas in ListaGranjas)
            {
                cboxCodigoGranja.Items.Add(Granjas);
            }
            cboxCodigoGranja.DisplayMember = "Text";
            cboxCodigoGranja.ValueMember = "Value";
        }

        private void MtdConsultarVenta()
        {
            DataTable dtUsuario = cd_ventas.MtdConsultarVenta();
            dgvVentas.DataSource = dtUsuario;
        }
        private void frmVentas_Load(object sender, EventArgs e)
        {
            MtdMostrarListaClientes();
            MtdMostrarListaGranjas();
            MtdConsultarVenta();
            lblFecha.Text = cl_ventas.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void mtdLimpiarCampos()
        {
            txtCodigoVenta.Text = "";
            cboxCodigoCliente.Text = "";
            cboxCodigoGranja.Text = "";
            txtTipoVenta.Text = "";
            txtTotalVenta.Text = "";
            cboxEstado.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoCliente = int.Parse(cboxCodigoCliente.Text.Split('-')[0].Trim());
                int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                DateTime FechaVenta = dtpFechaVenta.Value;
                string TipoVenta = txtTipoVenta.Text;
                decimal TotalVenta = decimal.Parse(txtTotalVenta.Text);
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_ventas.MtdFechaActual();

                cd_ventas.MtdAgregarVenta( CodigoCliente,  CodigoGranja,  FechaVenta,  TipoVenta,  TotalVenta,  Estado,  UsuarioAuditoria,  FechaAuditoria);
                MessageBox.Show("Venta agregada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarVenta();
                mtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoVenta = int.Parse(txtCodigoVenta.Text);
                int CodigoCliente = int.Parse(cboxCodigoCliente.Text.Split('-')[0].Trim());
                int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                DateTime FechaVenta = dtpFechaVenta.Value;
                string TipoVenta = txtTipoVenta.Text;
                decimal TotalVenta = decimal.Parse(txtTotalVenta.Text);
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_ventas.MtdFechaActual();

                cd_ventas.MtdActualizarVenta(CodigoVenta, CodigoCliente, CodigoGranja, FechaVenta, TipoVenta, TotalVenta, Estado, UsuarioAuditoria, FechaAuditoria);
                MessageBox.Show("Venta actualizada correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarVenta();
                mtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int CodigoVenta = int.Parse(txtCodigoVenta.Text);

            cd_ventas.MtdEliminarVenta(CodigoVenta);
            MessageBox.Show("Venta eliminada correctamente", "Eliminar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdConsultarVenta();
            mtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoVenta.Text = dgvVentas.SelectedCells[0].Value.ToString();
            cboxCodigoCliente.Text = dgvVentas.SelectedCells[1].Value.ToString();
            cboxCodigoGranja.Text = dgvVentas.SelectedCells[2].Value.ToString();
            dtpFechaVenta.Text = dgvVentas.SelectedCells[3].Value.ToString();
            txtTipoVenta.Text = dgvVentas.SelectedCells[4].Value.ToString();
            txtTotalVenta.Text = dgvVentas.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvVentas.SelectedCells[6].Value.ToString();
        }
    }
}
