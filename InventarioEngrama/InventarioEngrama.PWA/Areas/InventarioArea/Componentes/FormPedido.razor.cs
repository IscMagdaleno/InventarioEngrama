using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormPedido : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnDataSaved { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			ShowSnake(await Data.PostGetProveedor());
			Loading.Hide();
		}

		private async Task OnSubmint()
		{
			Loading.Show();

			var result = await Data.PostSavePedido();
			ShowSnake(result);
			if (result.bResult)
			{
				await OnDataSaved.InvokeAsync();
			}
			Loading.Hide();

		}

	}
}
