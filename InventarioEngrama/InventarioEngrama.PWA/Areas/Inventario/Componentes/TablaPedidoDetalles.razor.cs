using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.Inventario.Componentes
{
	public partial class TablaPedidoDetalles : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }


		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetPedidoDetalle();
			Loading.Hide();
		}
	}
}
