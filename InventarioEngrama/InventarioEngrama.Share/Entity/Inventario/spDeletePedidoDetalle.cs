using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spDeletePedidoDetalle
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spDeletePedidoDetalle"; }
			public int iIdPedidoDetalle { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
		}
	}

}
