using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class TablaApartados : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }

		[Parameter]
		public EventCallback EC_ApartadoSelected { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetApartado();
			Loading.Hide();
		}



		private async Task OnClickRow(Apartado articulo)
		{
			Data.ApartadoSelected = articulo;
		}
	}
}
