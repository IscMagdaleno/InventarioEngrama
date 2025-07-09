namespace InventarioEngrama.Share.PostClass.Inventario
{
	public class PostSavePedido
	{
		public int iIdPedido { get; set; }
		public int iIdProveedor { get; set; }
		public string nvchDescripcion { get; set; }
		public decimal mEnvio { get; set; }
	}
}
