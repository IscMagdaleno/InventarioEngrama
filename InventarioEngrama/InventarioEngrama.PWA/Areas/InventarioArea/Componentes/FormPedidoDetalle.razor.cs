using EngramaCoreStandar.Extensions;

using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormPedidoDetalle : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnPedidoDetalleSaved { get; set; }

		public bool ShowFormProducto { get; set; }
		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			ShowSnake(await Data.PostGetArticulo());
			Data.FilterArticuloByProvedor();

			Data.PedidoDetalleSelected.mPrecioUnitario = Data.ArticuloSelected.mPrecioCompra;

			Loading.Hide();
		}


		private async Task OnSubmint()
		{
			Loading.Show();
			var resultado = await Data.PostSavePedidoDetalle();
			ShowSnake(resultado);
			if (resultado.bResult)
			{
				await OnPedidoDetalleSaved.InvokeAsync();
			}
			Loading.Hide();
		}



		private void OnClickAddArticulo()
		{
			Data.ArticuloSelected = new Articulo();
			Data.ArticuloSelected.Proveedor = Data.ProveedorSelected;
			ShowFormProducto = ShowFormProducto.False();

		}

		private async Task OnDataArticuloSaved(Articulo articulo)
		{

			Data.PedidoDetalleSelected.mPrecioUnitario = articulo.mPrecioCompra;
			Data.PedidoDetalleSelected.Articulo = articulo;
			Data.PedidoDetalleSelected.iIdArticulo = articulo.iIdArticulo;

			ShowFormProducto = ShowFormProducto.False();
			await Task.Delay(1);
			StateHasChanged();
		}


	}
}
