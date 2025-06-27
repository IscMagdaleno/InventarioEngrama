using Microsoft.AspNetCore.Components;

using InventarioEngrama.PWA.Areas.TestModul.Utiles;
using InventarioEngrama.PWA.Shared.Common;

namespace InventarioEngrama.PWA.Areas.TestModul.Components
{
	public partial class TableTestTable : EngramaComponent
	{

		[Parameter] public DataTest Data { get; set; }

		protected override void OnInitialized()
		{

		}

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			ShowSnake(await Data.PostTestTable());
			Loading.Hide();
		}





	}
}
