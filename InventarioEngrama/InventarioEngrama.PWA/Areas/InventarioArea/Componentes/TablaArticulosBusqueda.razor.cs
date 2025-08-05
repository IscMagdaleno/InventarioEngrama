using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class TablaArticulosBusqueda : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnArticuloSelected { get; set; }




		private async Task OnClickRow(Articulo articulo)
		{

			Data.ArticuloSelected = articulo;
			await OnArticuloSelected.InvokeAsync();
		}
	}
}

