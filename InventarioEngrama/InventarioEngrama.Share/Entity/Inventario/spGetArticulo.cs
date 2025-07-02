using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spGetArticulo
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetArticulo"; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdProveedor { get; set; }
			public int iIdArticulo { get; set; }
			public string nvchNombre { get; set; }
			public string vchCodigo { get; set; }
			public decimal mPrecioCompra { get; set; }
			public decimal mPrecioVenta { get; set; }
		}
	}

}
