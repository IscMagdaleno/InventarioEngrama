using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.PostClass.Inventario
{
	public class spGetInventario
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetInventario"; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdInventario { get; set; }
			public int iIdArticulo { get; set; }
			public int smCantidad { get; set; }
			public string nvchNombreArticulo { get; set; }
			public string vchCodigo { get; set; }
			public decimal mPrecioCompra { get; set; }
			public decimal mPrecioVenta { get; set; }
			public int iIdProveedor { get; set; }
			public string nvchNombreProveedor { get; set; }
			public string vchTelefono { get; set; }
			public string nvchDireccion { get; set; }
		}
	}

}
