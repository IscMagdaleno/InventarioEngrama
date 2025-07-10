using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spGetVenta
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetVenta"; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdVenta { get; set; }
			public int iIdArticulo { get; set; }
			public int iCantidad { get; set; }
			public decimal mPrecioFinal { get; set; }
			public DateTime? dtFechaVenta { get; set; }
			public string vchReferenciaVenta { get; set; }
			public string nvchNombre { get; set; }
			public string vchCodigo { get; set; }
			public string nvchDescripcion { get; set; }
			public decimal mPrecioCompra { get; set; }
			public decimal mPrecioVenta { get; set; }
		}
	}

}
