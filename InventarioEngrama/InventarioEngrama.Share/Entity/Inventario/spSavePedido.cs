using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spSavePedido
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spSavePedido"; }
			public int iIdPedido { get; set; }
			public int iIdProveedor { get; set; }
			public string nvchDescripcion { get; set; }
			public decimal mEnvio { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdPedido { get; set; }
		}
	}


}
