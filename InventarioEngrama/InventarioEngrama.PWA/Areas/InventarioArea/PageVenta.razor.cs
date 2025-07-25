﻿using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.InventarioArea
{
	public partial class PageVenta : EngramaPage
	{

		public MainInventario Data { get; set; }

		public bool ShowArticulo { get; set; }
		protected override void OnInitialized()
		{
			Data = new MainInventario(httpService, mapperHelper, validaServicioService);
		}

		private void OnArticuloSelected()
		{
			ShowArticulo = true;

		}

		private async Task OnVentaSaved()
		{
			Loading.Show();
			var result = await Data.PostSaveVenta();
			ShowSnake(result);
			if (result.bResult)
			{
				ShowArticulo = false;
			}

			Loading.Hide();
		}

	}
}
