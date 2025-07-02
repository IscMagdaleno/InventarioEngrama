using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spGetPedido
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetPedido"; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdPedido { get; set; }
			public int iIdProveedor { get; set; }
			public DateTime? dtFecha { get; set; }
			public string nvchNombre { get; set; }
		}
	}

}
