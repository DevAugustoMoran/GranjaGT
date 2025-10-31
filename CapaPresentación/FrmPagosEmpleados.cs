using CapaDatos;
using CapaLogica;
using CapaPresentacion.Seguridad;
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
    public partial class FrmPagosEmpleados : Form
    {

        CDpagosEmpleados cdpagosempleados = new CDpagosEmpleados();
        CLpagosEmpleados clpagosempleados = new CLpagosEmpleados();

        public FrmPagosEmpleados()
        {
            InitializeComponent();
        }

        public void MtdConsultarPagosEmpleados()
        {
            DataTable dtpagosempleados = cdpagosempleados.MtdConsultarPagosEmpleados();
            dgvPagoEmpleados.DataSource = dtpagosempleados;
        }

        public void mtdLimpiarCampos()
        {
            txtCodigoPagoEmpleado.Text = "";
            txtSalario.Text = "";
            txtHorasExtra.Text = "";
            txtBonos.Text = "";
            txtDescuentos.Text = "";
            lblSalarioFinal.Text = "ImprimirSalario";
            dtpFechaPago.Value = DateTime.Now;
            cbxEstado.Text = "";
        }

        private void FrmPagosEmpleados_Load(object sender, EventArgs e)
        {
            lblFecha.Text = clpagosempleados.MtdFechaActual().ToString("dd/MM/yyyy");
            MtdMostrarListaEmpleados();
            MtdConsultarPagosEmpleados();
        }

        private void MtdMostrarListaEmpleados()
        {
            var ListaEmpleados = cdpagosempleados.MtdListarEmpleados();

            foreach (var Empleados in ListaEmpleados)
            {
                cboxCodigoEmpleado.Items.Add(Empleados);
            }

            cboxCodigoEmpleado.DisplayMember = "Text";
            cboxCodigoEmpleado.ValueMember = "Value";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtSalario.Text == "" || txtHorasExtra.Text == "" || txtBonos.Text == "" || txtDescuentos.Text == "" || lblSalarioFinal.Text == "ImprimirSalario" || cbxEstado.Text == "" || cboxCodigoEmpleado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Decimal salario = Convert.ToDecimal(txtSalario.Text);
                    Decimal horasExtra = Convert.ToDecimal(txtHorasExtra.Text);
                    Decimal bonos = Convert.ToDecimal(txtBonos.Text);
                    Decimal descuentos = Convert.ToDecimal(txtDescuentos.Text);
                    Decimal salarioFinal = Convert.ToDecimal(lblSalarioFinal.Text);
                    DateTime FechaPago = dtpFechaPago.Value;
                    string Estado = cbxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = clpagosempleados.MtdFechaActual();
                    int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                    cdpagosempleados.MtdAgregarPagoEmpleado(salario, horasExtra, bonos, descuentos, salarioFinal, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria, CodigoEmpleado);
                    MessageBox.Show("Pago de empleado agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarPagosEmpleados();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPagoEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoPagoEmpleado.Text = dgvPagoEmpleados.SelectedCells[0].Value.ToString();
            txtSalario.Text = dgvPagoEmpleados.SelectedCells[1].Value.ToString();
            txtHorasExtra.Text = dgvPagoEmpleados.SelectedCells[2].Value.ToString();
            txtBonos.Text = dgvPagoEmpleados.SelectedCells[3].Value.ToString();
            txtDescuentos.Text = dgvPagoEmpleados.SelectedCells[4].Value.ToString();
            lblSalarioFinal.Text = dgvPagoEmpleados.SelectedCells[5].Value.ToString();
            dtpFechaPago.Value = Convert.ToDateTime(dgvPagoEmpleados.SelectedCells[6].Value);
            cbxEstado.Text = dgvPagoEmpleados.SelectedCells[7].Value.ToString();
            cboxCodigoEmpleado.Text = dgvPagoEmpleados.SelectedCells[10].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigoPagoEmpleado.Text == "" || txtSalario.Text == "" || txtHorasExtra.Text == "" || txtBonos.Text == "" || txtDescuentos.Text == "" || lblSalarioFinal.Text == "ImprimirSalario" || cbxEstado.Text == "" || cboxCodigoEmpleado.Text == "")
            {
                MessageBox.Show("Por favor seleccione un pago de empleado para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoPagoEmpleado = Convert.ToInt32(txtCodigoPagoEmpleado.Text);
                    Decimal Salario = Convert.ToDecimal(txtSalario.Text);
                    Decimal HorasExtras = Convert.ToDecimal(txtHorasExtra.Text);
                    Decimal Bonos = Convert.ToDecimal(txtBonos.Text);
                    Decimal Descuentos = Convert.ToDecimal(txtDescuentos.Text);
                    Decimal SalarioFinal = Convert.ToDecimal(lblSalarioFinal.Text);
                    DateTime FechaPago = dtpFechaPago.Value;
                    string Estado = cbxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = clpagosempleados.MtdFechaActual();
                    int CodigoEmpleado = int.Parse(cboxCodigoEmpleado.Text.Split('-')[0].Trim());
                    cdpagosempleados.MtdActualizarPagoEmpleado(CodigoPagoEmpleado, Salario, HorasExtras, Bonos, Descuentos, SalarioFinal, FechaPago, Estado, UsuarioAuditoria, FechaAuditoria, CodigoEmpleado);
                    MessageBox.Show("Pago de empleado actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarPagosEmpleados();
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
            if (txtCodigoPagoEmpleado.Text == "")
            {
                MessageBox.Show("Por favor seleccione un pago de empleado para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoPagoEmpleado = Convert.ToInt32(txtCodigoPagoEmpleado.Text);
                    cdpagosempleados.MtdEliminarPagoEmpleado(CodigoPagoEmpleado);
                    MessageBox.Show("Pago de empleado eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarPagosEmpleados();
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

        private void lblSalarioFinal_Click(object sender, EventArgs e)
        {
            
        }

        private void dtpFechaPago_ValueChanged(object sender, EventArgs e)
        {

            

        }

        private void txtDescuentos_TextChanged(object sender, EventArgs e)
        {

            if (txtDescuentos.Text == "" || txtSalario.Text == "" || txtHorasExtra.Text == "")
            {
                lblSalarioFinal.Text = "-";
            }
            else if (txtBonos.Text != "")
            {
                lblSalarioFinal.Text = clpagosempleados.MtdCalcularSalarioFinal(Decimal.Parse(txtSalario.Text), Decimal.Parse(txtHorasExtra.Text), Decimal.Parse(txtBonos.Text), Decimal.Parse(txtDescuentos.Text)).ToString();
            }
        }

        private void txtBonos_TextChanged(object sender, EventArgs e)
        {
            if (txtBonos.Text == "" || txtSalario.Text == "" || txtHorasExtra.Text == "")
            {
                lblSalarioFinal.Text = "-";
            }
            else if (txtDescuentos.Text != "")
            {
                lblSalarioFinal.Text = clpagosempleados.MtdCalcularSalarioFinal(Decimal.Parse(txtSalario.Text), Decimal.Parse(txtHorasExtra.Text), Decimal.Parse(txtBonos.Text), Decimal.Parse(txtDescuentos.Text)).ToString();
            }
        }

    }
}
