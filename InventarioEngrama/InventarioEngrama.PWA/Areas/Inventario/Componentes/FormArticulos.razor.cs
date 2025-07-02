using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.Inventario.Componentes
{
	public partial class FormArticulos : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback OnDataSaved { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			ShowSnake(await Data.PostGetProveedor());

			if (Data.ArticuloSelected.iIdArticulo > 0 && Data.LstProveedores.Any())
			{
				Data.ProveedorSelected = Data.LstProveedores.SingleOrDefault(x => x.iIdProveedor == Data.ArticuloSelected.iIdProveedor);
			}
			Loading.Hide();
		}

		private async Task OnSubmint()
		{
			Loading.Show();

			var result = await Data.PostSaveArticulo();
			ShowSnake(result);
			if (result.bResult)
			{
				await OnDataSaved.InvokeAsync();
			}
			Loading.Hide();

		}
	}
}

