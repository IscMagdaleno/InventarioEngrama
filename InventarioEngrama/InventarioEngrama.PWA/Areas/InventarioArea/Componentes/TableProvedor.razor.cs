﻿using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class TableProvedor : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnProveedorSelected { get; set; }


		override protected async Task OnInitializedAsync()
		{
			Loading.Show();

			await Data.PostGetProveedor();
			Loading.Hide();

		}


		private async Task OnClickRow(Proveedor proveedor)
		{

			Data.ProveedorSelected = proveedor;
			await OnProveedorSelected.InvokeAsync();
		}

	}
}
