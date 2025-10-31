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
    public partial class FrmEmpleados : Form
    {
        CDempleados cd_empleados = new CDempleados();
        CLempleados cl_empleados = new CLempleados();

        //LLENAR COMBOBOX CON LISTAS
        private void MtdMostrarListaGranjas()
        {
            var ListaGranjas = cd_empleados.MtdListarGranjas();
            foreach (var Granjas in ListaGranjas)
            {
                cboxCodigoGranja.Items.Add(Granjas);
            }
            cboxCodigoGranja.DisplayMember = "Text";
            cboxCodigoGranja.ValueMember = "Value";
        }

        private void MtdMostrarListaUsuarios()
        {
            var ListaUsuarios = cd_empleados.MtdListarUsuarios();

            foreach (var Usuarios in ListaUsuarios)
            {
                cboxCodigoUsuario.Items.Add(Usuarios);
            }

            cboxCodigoUsuario.DisplayMember = "Text";
            cboxCodigoUsuario.ValueMember = "Value";
        }

        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            MtdMostrarListaGranjas();
            MtdMostrarListaUsuarios();
            MtdConsultarEmpleados();
            lblFecha.Text = cl_empleados.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void MtdConsultarEmpleados()
        {
            DataTable dtEmpleado = cd_empleados.MtdConsultarEmpleado();
            dgvRegistroEmpleados.DataSource = dtEmpleado;
        }

        private void mtdLimpiarCampos()
        {
            txtCodigoEmpleado.Text = "";
            cboxCodigoGranja.Text = "";
            cboxCodigoUsuario.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            cboxCargo.Text = "";
            txtSalarioBase.Text = "";
            cboxEstado.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboxCodigoGranja.Text == "" || cboxCodigoUsuario.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || cboxCargo.Text == "" ||txtSalario.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                    int CodigoUsuario = int.Parse(cboxCodigoUsuario.Text.Split('-')[0].Trim());
                    string Nombre = txtNombre.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Cargo = cboxCargo.Text;
                    decimal SalarioBase = decimal.Parse(txtSalarioBase.Text);
                    string Estado = cboxEstado.Text;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = cl_empleados.MtdFechaActual();
                    DateTime FechaRegistro = cl_empleados.MtdFechaActual();

                    cd_empleados.MtdAgregarEmpleado(CodigoGranja, CodigoUsuario, Nombre, Telefono, Correo, Cargo, Estado, SalarioBase, FechaAuditoria, UsuarioAuditoria, FechaRegistro);
                    MessageBox.Show("Empleado agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarEmpleados();
                    mtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboxCodigoGranja.Text == "" || cboxCodigoUsuario.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || cboxCargo.Text == "" || txtSalario.Text == "" || cboxEstado.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int CodigoEmpleado = int.Parse(txtCodigoEmpleado.Text);
                    int CodigoGranja = int.Parse(cboxCodigoGranja.Text.Split('-')[0].Trim());
                    int CodigoUsuario = int.Parse(cboxCodigoUsuario.Text.Split('-')[0].Trim());
                    string Nombre = txtNombre.Text;
                    string Telefono = txtTelefono.Text;
                    string Correo = txtCorreo.Text;
                    string Cargo = cboxCargo.Text;
                    string Estado = cboxEstado.Text;
                    decimal SalarioBase = decimal.Parse(txtSalarioBase.Text);
                    DateTime FechaIngreso = dtpFechaIngreso.Value;
                    string UsuarioAuditoria = UserCache.Nombre;
                    DateTime FechaAuditoria = cl_empleados.MtdFechaActual();

                    cd_empleados.MtdActualizarEmpleado(CodigoEmpleado, CodigoGranja, CodigoUsuario, Nombre, Telefono, Correo, Cargo, Estado, SalarioBase, FechaIngreso, UsuarioAuditoria, FechaAuditoria);
                    MessageBox.Show("Empleado actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdConsultarEmpleados();
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
            int CodigoEmpleado = int.Parse(txtCodigoEmpleado.Text);

            cd_empleados.MtdEliminarEmpleado(CodigoEmpleado);
            MessageBox.Show("Empleado eliminado correctamente", "Eliminar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdConsultarEmpleados();
            mtdLimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRegistroEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoEmpleado.Text = dgvRegistroEmpleados.SelectedCells[0].Value.ToString();
            cboxCodigoGranja.Text = dgvRegistroEmpleados.SelectedCells[1].Value.ToString();
            cboxCodigoUsuario.Text = dgvRegistroEmpleados.SelectedCells[2].Value.ToString();
            txtNombre.Text = dgvRegistroEmpleados.SelectedCells[3].Value.ToString();
            txtTelefono.Text = dgvRegistroEmpleados.SelectedCells[4].Value.ToString();
            txtCorreo.Text = dgvRegistroEmpleados.SelectedCells[5].Value.ToString();
            cboxCargo.Text = dgvRegistroEmpleados.SelectedCells[6].Value.ToString();
            cboxEstado.Text = dgvRegistroEmpleados.SelectedCells[7].Value.ToString();
            txtSalarioBase.Text = dgvRegistroEmpleados.SelectedCells[8].Value.ToString();
            dtpFechaIngreso.Text = dgvRegistroEmpleados.SelectedCells[9].Value.ToString();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
