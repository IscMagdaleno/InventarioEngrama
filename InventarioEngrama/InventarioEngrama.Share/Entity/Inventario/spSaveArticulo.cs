using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spSaveArticulo
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spSaveArticulo"; }
			public int iIdArticulo { get; set; }
			public int iIdProveedor { get; set; }
			public string nvchNombre { get; set; }
			public string vchCodigo { get; set; }
			public string nvchDescripcion { get; set; }

			public decimal mPrecioCompra { get; set; }
			public decimal mPrecioVenta { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdArticulo { get; set; }
		}
	}

}
