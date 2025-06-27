namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class Articulo
	{
		public int iIdArticulo { get; set; }
		public string nvchNombre { get; set; }
		public string vchCodigo { get; set; }
		public decimal mPrecioCompra { get; set; }
		public decimal mPrecioVenta { get; set; }
		public Articulo()
		{
			nvchNombre = string.Empty;
			vchCodigo = string.Empty;
		}

	}
}
