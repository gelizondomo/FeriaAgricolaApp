using FeriaAgricolaApp.Domain;
using FeriaAgricolaApp.Application.Controllers;
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
            CargarDirecciones();
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

        private void CargarDirecciones()
        {
            var direcciones = carritoController.ObtenerDireccionesDeEntrega(usuario.Id);
            cmbDirecciones.DataSource = direcciones;
            cmbDirecciones.DisplayMember = "DireccionCompleta";
            cmbDirecciones.ValueMember = "Id";
            if (direcciones.Count > 0)
                cmbDirecciones.SelectedIndex = 0;
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
            if (cmbDirecciones.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una dirección de entrega.");
                return;
            }

            var direccionSeleccionada = (Direccion)cmbDirecciones.SelectedItem;

            var resultado = carritoController.ProcesarCompra(
                usuario.Id,
                direccionSeleccionada.DireccionCompleta
            );

            if (!resultado.Exito)
            {
                MessageBox.Show("No se pudo procesar la compra. Verifique el carrito.");
                return;
            }

            MessageBox.Show($"Compra realizada.\nFactura: {resultado.Factura.CodigoFactura}\nTotal: {resultado.Factura.Total:C}");

            
            CargarCarrito();
        }
    }
}