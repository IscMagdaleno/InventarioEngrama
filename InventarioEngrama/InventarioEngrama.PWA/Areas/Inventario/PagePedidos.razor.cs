using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.Inventario
{
	public partial class PagePedidos : EngramaPage
	{
		public MainInventario Data { get; set; }


		public bool ShowNewProceso { get; set; }
		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
			ShowNewProceso = true;
		}


		private void CrearNuevoPedido()
		{
			ShowNewProceso = true;
		}

	}
}
