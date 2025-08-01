﻿using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageCrudProvedor : EngramaPage
	{
		public MainInventario Data { get; set; }

		public bool ShowForm { get; set; }
		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
		}


		private async Task OnDataSaved()
		{
			await Task.Delay(1);
			StateHasChanged();
		}

		private async Task OnProveedorSelected()
		{
			ShowForm = true;
		}

	}
}
