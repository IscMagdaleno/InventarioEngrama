using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormProvedores : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnSaveProvedor { get; set; }


		private async Task OnSubmint()
		{
			Loading.Show();
			var validacion = await Data.PostSaveProveedor();
			ShowSnake(validacion);
			if (validacion.bResult)
			{
				await OnSaveProvedor.InvokeAsync();
			}
			Loading.Hide();
		}

	}
}
