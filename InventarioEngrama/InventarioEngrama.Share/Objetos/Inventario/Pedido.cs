using EngramaCoreStandar;

namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class Pedido
	{
		public int iIdPedido { get; set; }
		public int iIdProveedor { get; set; }
		public DateTime? dtFecha { get; set; }
		public Pedido()
		{
			dtFecha = Defaults.SqlMinDate();
		}

	}
}
