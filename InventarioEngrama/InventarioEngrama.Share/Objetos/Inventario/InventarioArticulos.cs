namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class InventarioArticulos
	{
		public int iIdInventario { get; set; }
		public int iIdArticulo { get; set; }
		public int smCantidad { get; set; }
		public Articulo Articulo { get; set; }

		public InventarioArticulos()
		{
			Articulo = new Articulo();
		}
	}
}
