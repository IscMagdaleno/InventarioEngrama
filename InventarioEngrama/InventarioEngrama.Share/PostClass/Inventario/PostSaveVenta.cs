namespace InventarioEngrama.Share.PostClass.Inventario
{
	public class PostSaveVenta
	{
		public int iIdArticulo { get; set; }
		public int iCantidad { get; set; }
		public decimal mPrecioFinal { get; set; }
		public DateTime? dtFechaVenta { get; set; }
		public string vchReferenciaVenta { get; set; }
	}

}
