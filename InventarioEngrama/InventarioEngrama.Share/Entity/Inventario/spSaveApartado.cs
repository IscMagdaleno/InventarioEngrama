using EngramaCoreStandar.Dapper.Interfaces;

namespace InventarioEngrama.Share.Entity.Inventario
{
	public class spSaveApartado
	{
		public class Request : SpRequest
		{
			public string StoredProcedure { get => "spSaveApartado"; }
			public string nvchNombreCliente { get; set; }
			public decimal mTotal { get; set; }
			public bool bPagado { get; set; }
			public string nvchComentario { get; set; }
			public IEnumerable<DTApartadoDetalle> Detalles { get; set; }
		}
		public class Result : DbResult
		{
			public bool bResult { get; set; }
			public string vchMessage { get; set; }
			public int iIdApartado { get; set; }
		}
	}


	public class DTApartadoDetalle
	{
		public int iIdApartadoDetalle { get; set; }
		public int iIdApartado { get; set; }
		public int iIdArticulo { get; set; }
		public int iCantidad { get; set; }
		public decimal mPrecioFinal { get; set; }
	}
}
