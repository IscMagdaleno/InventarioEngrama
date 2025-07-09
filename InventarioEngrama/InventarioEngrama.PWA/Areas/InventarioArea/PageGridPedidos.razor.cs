using EngramaCoreStandar.Extensions;

using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageGridPedidos : EngramaPage
	{

		public MainInventario Data { get; set; }

		public bool ShowNewProceso { get; set; }

		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
			ShowNewProceso = false;
		}


		private void OnClickCambiarPantalla()
		{
			ShowNewProceso = ShowNewProceso.False();
		}


	}
}
