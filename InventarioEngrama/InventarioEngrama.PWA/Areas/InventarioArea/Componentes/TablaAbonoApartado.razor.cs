using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;
using InventarioEngrama.Share.Objetos.Inventario;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class TablaAbonoApartado : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Loading.Show();
			Data.LstAbonoApartados = new List<AbonoApartado>();

			await Data.PostGetAbonoApartado();
			Loading.Hide();
		}
	}
}
