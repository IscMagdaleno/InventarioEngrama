using InventarioEngrama.PWA.Areas.Inventario.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.Inventario.Componentes
{
	public partial class TableProvedor : EngramaComponent
	{

		[Parameter] public MainInventario Data { get; set; }


		override protected async Task OnInitializedAsync()
		{
			Loading.Show();

			ShowSnake(await Data.PostGetProveedor());
			Loading.Hide();

		}

	}
}
