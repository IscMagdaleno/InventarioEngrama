using InventarioEngrama.PWA.Areas.InventarioArea.Utiles;
using InventarioEngrama.PWA.Shared.Common;

using Microsoft.AspNetCore.Components;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Componentes
{
	public partial class ConsultaPedidos : EngramaComponent
	{
		[Parameter] public MainInventario Data { get; set; }

		[Parameter] public EventCallback OnEditarPedido { get; set; }
		public bool ShowTabla { get; set; }


		private void OnPedidoSelected()
		{
			ShowTabla = true;
		}

		private void OnVolverLista()
		{
			ShowTabla = false;
		}

	}
}
