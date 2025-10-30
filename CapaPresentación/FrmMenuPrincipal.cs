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
            frmInventarios formulario = new frmInventarios();
            formulario.Show();

            MtdOcultarSubMenu();
        }

        private void panelMenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            MtdMostrarSubMenu(panelUno);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientes formulario = new frmClientes();
            formulario.Show();

            MtdOcultarSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmEmpleados formulario = new FrmEmpleados();
            formulario.Show();

            MtdOcultarSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmPagosEmpleados formulario = new FrmPagosEmpleados();
            formulario.Show();

            MtdOcultarSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmPagosVentas formulario = new frmPagosVentas();
            formulario.Show();

            MtdOcultarSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmProveedores formulario = new frmProveedores();
            formulario.Show();

            MtdOcultarSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MtdMostrarSubMenu(panelDos);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmInsumos formulario = new frmInsumos();
            formulario.Show();

            MtdOcultarSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmProductos formulario = new frmProductos();
            formulario.Show();

            MtdOcultarSubMenu();
        }
    }
}
