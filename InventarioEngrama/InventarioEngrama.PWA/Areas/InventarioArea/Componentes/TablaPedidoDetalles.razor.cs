﻿using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class TablaPedidoDetalles : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnDetallePedidoSelected { get; set; }

		[Parameter] public bool ShowEdit { get; set; }
		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetPedidoDetalle();
			Loading.Hide();
		}


		private async Task OnClickRow(PedidoDetalle pedidoDetalle)
		{
			Data.ArticuloSelected = Data.LstArticulos.FirstOrDefault(e => e.iIdArticulo == pedidoDetalle.iIdArticulo);
			Data.PedidoDetalleSelected = pedidoDetalle;
			await OnDetallePedidoSelected.InvokeAsync();
		}
	}

}
