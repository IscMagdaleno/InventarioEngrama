using EngramaCoreStandar.Extensions;

using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageApartados : EngramaPage
	{

		public bool ShowNewApartado { get; set; }


		public MainInventario Data { get; set; }

		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
		}



		private void OnClickCambiarPantalla()
		{
			ShowNewApartado = ShowNewApartado.False();
		}
	}
}
