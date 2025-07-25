using EngramaCoreStandar;

namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class Apartado
	{
		public int iIdApartado { get; set; }
		public string nvchNombreCliente { get; set; }
		public DateTime? dtFechaApartado { get; set; }
		public decimal mTotal { get; set; }
		public bool bPagado { get; set; }
		public string nvchComentario { get; set; }
		public IList<ArticulosApartados> ArticulosApartados { get; set; }
		public Apartado()
		{
			dtFechaApartado = Defaults.SqlMinDate();
			nvchComentario = string.Empty;
			ArticulosApartados = new List<ArticulosApartados>();
		}

	}

}
