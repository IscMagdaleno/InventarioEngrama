using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spSaveAbonoApartado
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spSaveAbonoApartado"; }
			public int iIdAbonoApartado { get; set; }
			public int iIdApartado { get; set; }
			public decimal mAbono { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdAbonoApartado { get; set; }
		}
	}

}
