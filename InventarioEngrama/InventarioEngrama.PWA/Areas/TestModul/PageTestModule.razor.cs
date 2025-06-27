using InventarioEngrama.PWA.Areas.TestModul.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.TestModul
{
	public partial class PageTestModule : EngramaPage
	{


		public DataTest Data { get; set; }

		protected override void OnInitialized()
		{
			Data = new DataTest(httpService, mapperHelper, validaServicioService);
		}

		protected override async Task OnInitializedAsync()
		{
		}



	}
}
