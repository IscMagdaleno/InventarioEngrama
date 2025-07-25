namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class ArticulosApartados
	{
		public int iIdApartadoDetalle { get; set; }
		public int iIdApartado { get; set; }
		public int iIdArticulo { get; set; }
		public int iCantidad { get; set; }
		public decimal mPrecioFinal { get; set; }
		public string vchReferenciaVenta { get; set; }
		public bool bEntregado { get; set; }
		public Articulo Articulo { get; set; }


		public ArticulosApartados()
		{
			Articulo = new Articulo();


		}
	}

}
