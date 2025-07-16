using InventarioEngrama.Share.Objetos.Inventario;

namespace InventarioEngrama.Share.PostClass.Inventario
{
	public class PostSaveApartado
	{

		public string nvchNombreCliente { get; set; }
		public decimal mTotal { get; set; }
		public bool bPagado { get; set; }
		public string nvchComentario { get; set; }
		public IList<ApartadoDetalle> LstDetalles { get; set; }
	}

}
