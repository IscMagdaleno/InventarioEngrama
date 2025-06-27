using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spGetProveedor
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetProveedor"; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdProveedor { get; set; }
			public string nvchNombre { get; set; }
			public string vchTelefono { get; set; }
			public string nvchDireccion { get; set; }
		}
	}

}
