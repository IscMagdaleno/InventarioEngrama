using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class GridSeleccionArticulo : EngramaComponent
	{


		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnProductSaved { get; set; }
		[Parameter] public EventCallback OnCancelVenta { get; set; }

		public bool ShowArticulo { get; set; }
		protected override void OnInitialized()
		{

		}


		private async Task OnVentaSaved()
		{
			await OnProductSaved.InvokeAsync();

		}

	}
}
