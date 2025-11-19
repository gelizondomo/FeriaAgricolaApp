using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Presentation.Controllers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaAgricolaApp.Presentation.Views
{
    public partial class FrmCarrito : Form
    {
        private readonly CarritoController carritoController;
        private readonly Usuario usuario;

        public FrmCarrito(CarritoController carritoController, Usuario usuario)
        {
            this.carritoController = carritoController;
            this.usuario = usuario;
            InitializeComponent();
            CargarCarrito();
        }

        private void CargarCarrito()
        {
            var order = carritoController.ObtenerCarrito(usuario.Id);

            var lista = order.Items
            .Select(i => new
            {
                ProductoId = i.ProductoId,
                Producto = carritoController.ObtenerNombreProducto(i.ProductoId),
                Cantidad = i.Cantidad,
                TotalLinea = carritoController.ObtenerTotalProducto(i.ProductoId, i.Cantidad)
            })
            .ToList();

            dgvCarrito.DataSource = lista;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            int productoId = (int)dgvCarrito.SelectedRows[0].Cells["ProductoId"].Value;

            carritoController.QuitarProducto(usuario.Id, productoId);
            CargarCarrito();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            var direccion = txtDireccion.Text.Trim();
            if (string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Ingrese una dirección de entrega.");
                return;
            }

            var resultado = carritoController.ProcesarCompra(usuario.Id, direccion);

            if (!resultado.Exito)
            {
                MessageBox.Show("No se pudo completar la compra.");
                return;
            }

            _ = MessageBox.Show(
                $"Compra realizada.\nFactura generada: {resultado.Factura.CodigoFactura}",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            CargarCarrito();
        }
    }
}