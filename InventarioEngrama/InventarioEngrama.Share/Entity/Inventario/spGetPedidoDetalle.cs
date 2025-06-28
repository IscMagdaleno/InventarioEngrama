using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spGetPedidoDetalle
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetPedidoDetalle"; }
			public int iIdPedido { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdPedidoDetalle { get; set; }
			public int iIdPedido { get; set; }
			public int iIdArticulo { get; set; }
			public int smCantidad { get; set; }
			public decimal mPrecioUnitario { get; set; }
			public string nvchNombre { get; set; }
			public string vchCodigo { get; set; }
			public decimal mPrecioCompra { get; set; }
			public decimal mPrecioVenta { get; set; }
		}
	}

}
