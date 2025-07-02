using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.Inventario.Componentes
{
	public partial class TablaPedidoDetalles : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }


		[Parameter]
		public EventCallback OnDetallePedidoSelected { get; set; }
		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetPedidoDetalle();
			Loading.Hide();
		}


		private async Task OnClickRow(PedidoDetalle pedidoDetalle)
		{

			Data.ArticuloSelected = Data.LstArticulos.SingleOrDefault(e => e.iIdArticulo == pedidoDetalle.iIdArticulo);
			Data.PedidoDetalleSelected = pedidoDetalle;
			await OnDetallePedidoSelected.InvokeAsync();
		}
	}

}
