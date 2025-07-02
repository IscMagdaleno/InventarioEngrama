using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.Inventario.Componentes
{
	public partial class ProcesoNuevoPedido : EngramaComponent
	{
		[Parameter]
		public MainInventario Data { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			ShowSnake(await Data.PostGetProveedor());
			Loading.Hide();
		}

		private async Task OnCrearNuevoPedido()
		{
			Loading.Show();
			ShowSnake(await Data.PostSavePedido());
			Loading.Hide();
		}


		private async Task OnPedidoDetalleSaved()
		{
			await Task.Delay(1);
			StateHasChanged();
		}

		private async Task OnDetallePedidoSelected()
		{
			await Task.Delay(1);
			StateHasChanged();
		}
	}
}
