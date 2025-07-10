using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.PostClass.Inventario
{
	public class spSaveVenta
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spSaveVenta"; }
			public int iIdArticulo { get; set; }
			public int iCantidad { get; set; }
			public decimal mPrecioFinal { get; set; }
			public DateTime? dtFechaVenta { get; set; }
			public string vchReferenciaVenta { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdVenta { get; set; }
		}
	}

}
