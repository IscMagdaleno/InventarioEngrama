using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class GridPedidos : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnPedidoSelected { get; set; }
		[Parameter] public EventCallback OnEditarPedido { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetPedido();
			Loading.Hide();

		}


		private async Task OnClickEditarPedido(Pedido pedido)
		{
			Data.PedidoSelected = pedido;
			await OnEditarPedido.InvokeAsync();
		}
		private async Task OnClickPedidoSelected(Pedido pedido)
		{
			Data.PedidoSelected = pedido;
			await OnPedidoSelected.InvokeAsync();
		}
	}
}
