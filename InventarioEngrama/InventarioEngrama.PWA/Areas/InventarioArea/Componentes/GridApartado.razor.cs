using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class GridApartado : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback EC_ApartadorSaved { get; set; }

		public bool ShowApartadoDetalle { get; set; }


		private async Task EC_ApartadoFilled()
		{
			ShowApartadoDetalle = true;
		}

		private async Task OnArticuloSelected()
		{

			await Task.Delay(1);
			StateHasChanged();

		}
		private void OnVentaSaved()
		{

			Data.AddArticuloToApartado();
		}

		private async Task OnClickGuradarApartado()
		{
			Loading.Show();
			var result = await Data.PostSaveApartado();
			ShowSnake(result);
			if (result.bResult)
			{
				await EC_ApartadorSaved.InvokeAsync();
			}

			Loading.Hide();
		}
	}
}
