using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.Inventario.Componentes
{
	public partial class FormPedidoDetalle : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnPedidoDetalleSaved { get; set; }


		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			ShowSnake(await Data.PostGetArticulo());
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
	}
}
