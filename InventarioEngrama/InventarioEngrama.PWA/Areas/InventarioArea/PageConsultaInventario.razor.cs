using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageConsultaInventario : EngramaPage
	{
		public MainInventario Data { get; set; }

		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
		}


		protected override async Task OnInitializedAsync()
		{
			await Data.PostGetInventario();
		}
	}
}
