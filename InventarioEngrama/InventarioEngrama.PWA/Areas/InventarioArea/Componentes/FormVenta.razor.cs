using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormVenta : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }

		[Parameter]
		public EventCallback OnVentaSaved { get; set; }

		protected override void OnParametersSet()
		{

			Data.VentaSelected.mPrecioFinal = Data.ArticuloSelected.mPrecioVenta;

		}

		private void OnBlurCantidad()
		{
			Data.VentaSelected.mPrecioFinal = Data.ArticuloSelected.mPrecioVenta * Data.VentaSelected.iCantidad;
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
