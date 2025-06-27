using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.Inventario.Componentes
{
	public partial class FormArticulos : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }

		[Parameter] public EventCallback OnDataSaved { get; set; }

		private async Task OnSubmint()
		{
			Loading.Show();

			var result = await Data.PostSaveArticulo();
			ShowSnake(result);
			if (result.bResult)
			{
				await OnDataSaved.InvokeAsync();
			}
			Loading.Hide();

		}
	}
}

