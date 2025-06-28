namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class PedidoDetalle
	{
		public int iIdPedidoDetalle { get; set; }
		public int iIdPedido { get; set; }
		public int iIdArticulo { get; set; }
		public int smCantidad { get; set; }
		public decimal mPrecioUnitario { get; set; }

		public Articulo Articulo { get; set; }
		public PedidoDetalle()
		{
			Articulo = new Articulo();
		}

	}
}
