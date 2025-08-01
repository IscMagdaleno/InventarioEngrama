﻿using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class ProcesoNuevoPedido : EngramaComponent
	{
		[Parameter]
		public MainInventario Data { get; set; }

		protected override void OnInitialized()
		{
			if (Data.PedidoSelected.iIdPedido > 0)
			{
				Data.ProveedorSelected = Data.PedidoSelected.Proveedor;
			}
		}

		private async Task OnDataSaved()
		{
			Loading.Show();
			await Task.Delay(1);
			StateHasChanged();
			Loading.Hide();
		}


		private async Task OnPedidoDetalleSaved()
		{
			await Task.Delay(1);
			StateHasChanged();
		}

		private async Task OnDetallePedidoSelected()
		{
			await Task.Delay(1);
			StateHasChanged();
		}
	}
}
