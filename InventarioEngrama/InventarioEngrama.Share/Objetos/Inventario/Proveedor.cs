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

	}
}
