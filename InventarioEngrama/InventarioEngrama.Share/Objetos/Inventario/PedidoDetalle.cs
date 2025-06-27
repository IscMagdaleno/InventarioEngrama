namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class PedidoDetalle
	{
		public int iIdPedido { get; set; }
		public int iIdProveedor { get; set; }
		public int iIdArticulo { get; set; }
		public int smCantidad { get; set; }
		public decimal mPrecioUnitario { get; set; }
		public PedidoDetalle()
		{
		}

	}
}
