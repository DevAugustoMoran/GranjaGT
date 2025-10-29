using CapaDatos;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentación
{
    public partial class FrmUsuarios : Form
    {
        CDusuarios cd_usuarios = new CDusuarios();
        CLusuarios cl_usuarios = new CLusuarios();
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        //LLENAR COMBOBOX CON LISTA DE USUARIOS
        private void MtdMostrarListaUsuarios()
        {
            var ListaUsuarios = cd_usuarios.MtdListarUsuarios();

            foreach (var Usuarios in ListaUsuarios)
            {
                cboxCodigoRol.Items.Add(Usuarios);
            }

            cboxCodigoRol.DisplayMember = "Text";
            cboxCodigoRol.ValueMember = "Value";
        }


        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            MtdMostrarListaUsuarios();
            MtdConsultarUsuario();
            lblFecha.Text = cl_usuarios.MtdFechaActual().ToString("dd/MM/yyyy");
        }

        private void MtdConsultarUsuario()
        {
            DataTable dtUsuario = cd_usuarios.MtdConsultarUsuario();
            dgvRegistroUsuarios.DataSource = dtUsuario;
        }

        private void mtdLimpiarCampos()
        {
            txtCodigoUsuario.Text = "";
            cboxCodigoRol.Text = "";
            txtNombre.Text = "";
            cboxEstado.Text = "";
        }


        
        private void txtNivelAcceso_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoRol = int.Parse(cboxCodigoRol.Text.Split('-')[0].Trim());
                string Nombre = txtNombre.Text;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_usuarios.MtdFechaActual();
                DateTime FechaRegistro = cl_usuarios.MtdFechaActual();

                cd_usuarios.MtdAgregarUsuario(CodigoRol, Nombre, Estado, UsuarioAuditoria, FechaAuditoria, FechaRegistro);
                MessageBox.Show("Usuario agregado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarUsuario();
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
                int CodigoUsuario = int.Parse(txtCodigoUsuario.Text);
                int CodigoRol = int.Parse(cboxCodigoRol.Text.Split('-')[0].Trim());
                string Nombre = txtNombre.Text;
                string Estado = cboxEstado.Text;
                string UsuarioAuditoria = "Admin"; //Hay que cambiarlo
                DateTime FechaAuditoria = cl_usuarios.MtdFechaActual();
                DateTime FechaRegistro = dtpFechaRegistro.Value;

                cd_usuarios.MtdActualizarUsuario( CodigoUsuario,  CodigoRol,  Nombre,  Estado, UsuarioAuditoria,  FechaAuditoria,  FechaRegistro);
                MessageBox.Show("Usuario actualizado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdConsultarUsuario();
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
            int CodigoUsuario = int.Parse(txtCodigoUsuario.Text);

            cd_usuarios.MtdEliminarUsuario(CodigoUsuario);
            MessageBox.Show("Usuario eliminado correctamente", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdConsultarUsuario();
            mtdLimpiarCampos();
        }

        private void dgvRegistroUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoUsuario.Text = dgvRegistroUsuarios.SelectedCells[0].Value.ToString();
            cboxCodigoRol.Text = dgvRegistroUsuarios.SelectedCells[1].Value.ToString();
            txtNombre.Text = dgvRegistroUsuarios.SelectedCells[2].Value.ToString();
            cboxEstado.Text = dgvRegistroUsuarios.SelectedCells[3].Value.ToString();
            dtpFechaRegistro.Text = dgvRegistroUsuarios.SelectedCells[6].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
