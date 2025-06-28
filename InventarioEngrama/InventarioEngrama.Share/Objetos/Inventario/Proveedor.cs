namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class Proveedor
	{
		public int iIdProveedor { get; set; }
		public string nvchNombre { get; set; }
		public string vchTelefono { get; set; }
		public string nvchDireccion { get; set; }
		public Proveedor()
		{
			nvchNombre = string.Empty;
			vchTelefono = string.Empty;
			nvchDireccion = string.Empty;
		}


		// Note: this is important so the select can compare pizzas
		public override bool Equals(object o)
		{
			var other = o as Proveedor;
			return other?.nvchNombre == nvchNombre;
		}

		// Note: this is important so the select can compare pizzas
		public override int GetHashCode() => nvchNombre.GetHashCode();
		public override string ToString() => nvchNombre;

	}
}
