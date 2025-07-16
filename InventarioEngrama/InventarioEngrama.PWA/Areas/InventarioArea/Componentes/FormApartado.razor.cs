using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormApartado : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }

		[Parameter] public EventCallback EC_ApartadoFilled { get; set; }


		private async Task OnSubmint()
		{
			Data.ApartadoSelected.dtFechaApartado = DateTime.UtcNow;
			await EC_ApartadoFilled.InvokeAsync();

		}
	}
}
