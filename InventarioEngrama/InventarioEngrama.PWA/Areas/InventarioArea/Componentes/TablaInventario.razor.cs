using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class TablaInventario : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }

		[Parameter] public bool ShowSeleccionar { get; set; }
		[Parameter] public EventCallback OnArticuloSelected { get; set; }




		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetInventario();
			Loading.Hide();

		}

		private async Task OnClickArticulo(InventarioArticulos inventarioArticulos)
		{
			if (Data.ArticuloSelected != null)
			{
				Data.ArticuloSelected = Data.LstArticulosInventario
				.FirstOrDefault(e => e.iIdArticulo == inventarioArticulos.iIdArticulo).Articulo;

			}

			await OnArticuloSelected.InvokeAsync();
		}
	}
}
