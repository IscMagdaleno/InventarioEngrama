﻿using EngramaCoreStandar;

namespace InventarioEngrama.Share.Objetos.Inventario
{
	public class Pedido
	{
		public int iIdPedido { get; set; }
		public int iIdProveedor { get; set; }
		public string nvchDescripcion { get; set; }
		public decimal mEnvio { get; set; }
		public DateTime? dtFecha { get; set; }

		public Proveedor Proveedor { get; set; }

		public List<PedidoDetalle> Detalles { get; set; }
		public Pedido()
		{
			dtFecha = Defaults.SqlMinDate();
			nvchDescripcion = string.Empty;
		}

	}
}
