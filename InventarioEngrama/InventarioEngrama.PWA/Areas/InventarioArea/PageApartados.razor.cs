using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageApartados : EngramaPage
	{

		public bool ShowTablaApartado { get; set; }
		public bool ShowNewApartado { get; set; }
		public bool ShowEditApartado { get; set; }


		public MainInventario Data { get; set; }

		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
			ShowTablaApartado = true;
		}



		private void OnClickAddApartado()
		{
			Data.ApartadoSelected = new Apartado();
			ShowNewApartado = true;
			ShowTablaApartado = false;
			ShowEditApartado = false;
		}

		private void OnClickCambiarPantalla()
		{
			Data.ApartadoSelected = new Apartado();
			ShowNewApartado = false;
			ShowTablaApartado = true;
			ShowEditApartado = false;
		}

		private void EC_ApartadoSelected()
		{
			ShowNewApartado = false;
			ShowTablaApartado = false;
			ShowEditApartado = true;
		}
	}
}
