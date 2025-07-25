using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spGetApartadoDetalle
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetApartadoDetalle"; }
			public int iIdApartado { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdApartadoDetalle { get; set; }
			public int iIdApartado { get; set; }
			public int iIdArticulo { get; set; }
			public string nvchNombreArticulo { get; set; }
			public string vchCodigo { get; set; }
			public string nvchDescripcion { get; set; }
			public decimal mPrecioCompra { get; set; }
			public decimal mPrecioVenta { get; set; }
			public int iCantidad { get; set; }
			public decimal mPrecioFinal { get; set; }
		}
	}

}
