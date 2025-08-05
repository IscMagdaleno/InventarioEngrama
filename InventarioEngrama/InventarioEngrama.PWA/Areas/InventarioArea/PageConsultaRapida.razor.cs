using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageConsultaRapida : EngramaPage
	{
		public MainInventario Data { get; set; }

		public bool ShowForm { get; set; }


		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
			ShowForm = false;
		}

		override protected async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetArticulo();

			await Data.PostGetProveedor();
			Loading.Hide();

		}

		private async Task EC_ProveedorSelected(Proveedor proveedor)
		{
			Data.ProveedorSelected = proveedor;
			Data.FilterTmpArticuloByProvedor();

			StateHasChanged();
			await Task.Delay(1);
		}
		private async Task OnArticuloSelected()
		{

			StateHasChanged();
			await Task.Delay(1);

		}
	}

}
