using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormVenta : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }

		[Parameter] public EventCallback OnVentaSaved { get; set; }
		[Parameter] public EventCallback OnCancelVenta { get; set; }

		protected override void OnParametersSet()
		{

			Data.VentaSelected.mPrecioFinal = Data.ArticuloSelected.mPrecioVenta;

		}

		private void OnBlurCantidad()
		{
			Data.VentaSelected.mPrecioFinal = Data.ArticuloSelected.mPrecioVenta * Data.VentaSelected.iCantidad;
		}

		private async Task OnClickCancelar()
		{
			Data.ArticuloSelected = new Articulo();
			await OnCancelVenta.InvokeAsync();
		}

		private async Task OnSubmint()
		{
			Loading.Show();
			Data.PostSaveVentaLocal();

			await OnVentaSaved.InvokeAsync();


			Loading.Hide();
		}
	}
}
