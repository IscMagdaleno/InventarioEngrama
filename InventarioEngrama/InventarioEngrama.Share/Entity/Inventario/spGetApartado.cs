using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spGetApartado
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spGetApartado"; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdApartado { get; set; }
			public string nvchNombreCliente { get; set; }
			public DateTime? dtFechaApartado { get; set; }
			public decimal mTotal { get; set; }
			public bool bPagado { get; set; }
			public string nvchComentario { get; set; }
			public int iIdApartadoDetalle { get; set; }
			public int iIdArticulo { get; set; }
			public int iCantidad { get; set; }
			public decimal mPrecioFinal { get; set; }
		}
	}

}
