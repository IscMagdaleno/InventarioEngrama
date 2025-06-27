namespace InventarioEngrama.Share.PostClass.Inventario
{
	public class PostSavePedidoDetalle
	{
		public int iIdPedido { get; set; }
		public int iIdProveedor { get; set; }
		public int iIdArticulo { get; set; }
		public int smCantidad { get; set; }
		public decimal mPrecioUnitario { get; set; }
	}

}
