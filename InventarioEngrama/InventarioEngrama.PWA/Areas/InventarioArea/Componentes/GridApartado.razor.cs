using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class GridApartado : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }

		public bool ShowApartadoDetalle { get; set; }


		private async Task EC_ApartadoFilled()
		{
			ShowApartadoDetalle = true;
		}

		private async Task OnArticuloSelected()
		{

		}
	}
}
