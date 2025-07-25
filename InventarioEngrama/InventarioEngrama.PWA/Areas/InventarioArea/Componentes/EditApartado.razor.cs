using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class EditApartado : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			await Data.PostGetArticulosApartados();
			Loading.Hide();
		}
		private async Task OnDataSaved()
		{
			await Task.Delay(1);
			StateHasChanged();
		}
	}
}
