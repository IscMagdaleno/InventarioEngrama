using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class TablaArticulos : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnArticuloSelected { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetArticulo();
			Loading.Hide();
		}


		private async Task OnClickRow(Articulo articulo)
		{

			Data.ArticuloSelected = articulo;
			await OnArticuloSelected.InvokeAsync();
		}
	}
}
