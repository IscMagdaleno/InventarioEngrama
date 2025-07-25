using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormAbonoApartado : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnDataSaved { get; set; }

		private async Task OnSubmint()
		{
			Loading.Show();

			var result = await Data.PostSaveAbonoApartado();
			ShowSnake(result);
			if (result.bResult)
			{
				await OnDataSaved.InvokeAsync();
			}
			Loading.Hide();

		}
	}
}
