namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class Articulo
	{
		public int iIdArticulo { get; set; }
		public int iIdProveedor { get; set; }
		public string nvchNombre { get; set; }
		public string vchCodigo { get; set; }
		public string nvchDescripcion { get; set; }
		public decimal mPrecioCompra { get; set; }
		public decimal mPrecioVenta { get; set; }
		public Proveedor Proveedor { get; set; }

		public Articulo()
		{
			nvchNombre = string.Empty;
			vchCodigo = string.Empty;
			nvchDescripcion = string.Empty;
			Proveedor = new Proveedor();
		}



		// Note: this is important so the select can compare pizzas
		public override bool Equals(object o)
		{
			var other = o as Articulo;
			return other?.nvchNombre == nvchNombre;
		}

		// Note: this is important so the select can compare pizzas
		public override int GetHashCode() => nvchNombre.GetHashCode();

		public override string ToString() => nvchNombre;

	}
}
