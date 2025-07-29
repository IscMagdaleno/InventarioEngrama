using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class FormArticulos : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }
		[Parameter] public EventCallback<Articulo> OnDataSaved { get; set; }

		[Parameter] public bool DisableProveedor { get; set; }
		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			ShowSnake(await Data.PostGetProveedor());



			Loading.Hide();
		}

		private async Task OnSubmint()
		{
			Loading.Show();

			var result = await Data.PostSaveArticulo();
			ShowSnake(result);
			if (result.bResult)
			{
				await OnDataSaved.InvokeAsync(Data.ArticuloSelected);
				Data.ArticuloSelected = new Articulo();

			}
			Loading.Hide();

		}
	}
}

