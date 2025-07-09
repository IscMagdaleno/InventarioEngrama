namespace InventarioEngrama.Share.PostClass.Inventario
{
	public class PostSaveArticulo
	{
		public int iIdArticulo { get; set; }
		public int iIdProveedor { get; set; }
		public string nvchNombre { get; set; }
		public string vchCodigo { get; set; }
		public string nvchDescripcion { get; set; }
		public decimal mPrecioCompra { get; set; }
		public decimal mPrecioVenta { get; set; }
	}

}
