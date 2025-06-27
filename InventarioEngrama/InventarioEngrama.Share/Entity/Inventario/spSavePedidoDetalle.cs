using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spSavePedidoDetalle
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spSavePedidoDetalle"; }
			public int iIdPedido { get; set; }
			public int iIdProveedor { get; set; }
			public int iIdArticulo { get; set; }
			public int smCantidad { get; set; }
			public decimal mPrecioUnitario { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdPedidoDetalle { get; set; }
		}
	}

}
