using EngramaCoreStandar;

namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class Venta
	{
		public int iIdVenta { get; set; }
		public int iIdArticulo { get; set; }
		public int iCantidad { get; set; }
		public decimal mPrecioFinal { get; set; }
		public DateTime? dtFechaVenta { get; set; }
		public string vchReferenciaVenta { get; set; }

		public Articulo Articulo { get; set; }
		public Venta()
		{
			iCantidad = 1;
			dtFechaVenta = Defaults.SqlMinDate();
			vchReferenciaVenta = string.Empty;
		}

	}
}
