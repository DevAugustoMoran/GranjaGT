using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaPresentación
{
    public partial class frmVentasDetalle: Form
    {
        CDventasDetalle cd_ventasdetalle = new CDventasDetalle();

        public frmVentasDetalle()
        {
            InitializeComponent();
        }

        private void frmVentasDetalle_Load(object sender, EventArgs e)
        {

        }

        private void MtdMostrarListaVenta()
        {
            var ListaVentas = cd_ventasdetalle.MtdListarVentas();

            foreach (var Ventas in ListaVentas)
            {
                cboxCodigoVenta.Items.Add(Ventas);
            }

            cboxCodigoVenta.DisplayMember = "Text";
            cboxCodigoVenta.ValueMember = "Value";
        }

        private void MtdMostrarListaAnimal()
        {
            var ListaAnimal = cd_ventasdetalle.MtdListarAnimal();

            foreach (var Animal in ListaAnimal)
            {
                cboxCodigoAnimal.Items.Add(Animal);
            }

            cboxCodigoAnimal.DisplayMember = "Text";
            cboxCodigoAnimal.ValueMember = "Value";
        }

        private void MtdMostrarListaCultivo()
        {
            var ListaCultivo = cd_ventasdetalle.MtdListarCultivo();

            foreach (var Cultivo in ListaCultivo)
            {
                cboxCodigoCultivo.Items.Add(Cultivo);
            }

            cboxCodigoCultivo.DisplayMember = "Text";
            cboxCodigoCultivo.ValueMember = "Value";
        }

        private void MtdMostrarListaProducto()
        {
            var ListaProductos = cd_ventasdetalle.MtdListarProducto();

            foreach (var Productos in ListaProductos)
            {
                cboxCodigoProducto.Items.Add(Productos);
            }

            cboxCodigoProducto.DisplayMember = "Text";
            cboxCodigoProducto.ValueMember = "Value";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dgvConsumos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
