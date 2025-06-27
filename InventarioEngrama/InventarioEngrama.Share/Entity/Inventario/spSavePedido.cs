using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spSavePedido
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spSavePedido"; }
			public int iIdProveedor { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdPedido { get; set; }
		}
	}

}
