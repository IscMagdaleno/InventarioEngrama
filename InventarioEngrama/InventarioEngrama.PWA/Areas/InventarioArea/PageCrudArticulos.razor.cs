using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageCrudArticulos : EngramaPage
	{
		public MainInventario Data { get; set; }

		public bool ShowForm { get; set; }
		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
			ShowForm = false;
		}


		private async Task OnDataSaved()
		{
			await Task.Delay(1);
			StateHasChanged();
		}


		private async Task OnArticuloSelected()
		{

			if (Data.ArticuloSelected.iIdArticulo > 0 && Data.LstProveedores.Any())
			{
				Data.ArticuloSelected.Proveedor = Data.LstProveedores.SingleOrDefault(x => x.iIdProveedor == Data.ArticuloSelected.iIdProveedor);
			}
			ShowForm = true;
		}
	}

}
