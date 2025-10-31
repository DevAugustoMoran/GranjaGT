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
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            MtdPersonalizarDiseño();
            
        }

        private void MtdPersonalizarDiseño()
        {
            panelUno.Visible = false;
            panelDos.Visible = false;
            panelTres.Visible = false;
            panelCuatro.Visible = false;
            panelCinco.Visible = false;
        }

        private void MtdOcultarSubMenu()
        {
            if (panelUno.Visible == true)
                panelUno.Visible = false;
            if (panelDos.Visible == true)
                panelDos.Visible = false;
            if (panelTres.Visible == true)
                panelTres.Visible = false;
            if (panelCuatro.Visible == true)
                panelCuatro.Visible = false;
            if (panelCinco.Visible == true)
                panelCinco.Visible = false;
        }

        private void MtdMostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                MtdOcultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmInventarios());
        }

        private void panelMenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            MtdMostrarSubMenu(panelUno);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmClientes());

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new FrmEmpleados());

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new FrmPagosEmpleados());

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmPagosVentas());

           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmProveedores());

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MtdMostrarSubMenu(panelDos);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmInsumos());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmProductos());
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            MtdMostrarSubMenu(panelTres);
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            MtdMostrarSubMenu(panelCuatro);
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            MtdMostrarSubMenu(panelCinco);
        }


        private Form FormActivo = null;
        private void MtdAbrirContenedorFormulario(Form formularioHijo)
        {
            if(FormActivo != null)
                FormActivo.Close();
            FormActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedorForm.Controls.Add(formularioHijo);
            panelContenedorForm.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmVentas());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmVentasDetalle());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmEnvios());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmAnimales());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmCultivos());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new FrmGranjas());
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new frmRoles());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MtdAbrirContenedorFormulario(new FrmUsuarios());
        }

        private void LoadUserData()
        {
            lblUsuario.Text = UserCache.Nombre;
            lblRol.Text = UserCache.NombreRol;
            lblEstado.Text = UserCache.Estado;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
