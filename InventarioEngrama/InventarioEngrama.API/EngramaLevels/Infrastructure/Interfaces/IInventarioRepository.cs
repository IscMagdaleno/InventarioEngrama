﻿using InventarioEngrama.Share.Entity.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

namespace InventarioEngrama.API.EngramaLevels.Infrastructure.Interfaces
{
	public interface IInventarioRepository
	{
		Task<spDeletePedidoDetalle.Result> spDeletePedidoDetalle(spDeletePedidoDetalle.Request PostModel);
		Task<IEnumerable<spGetAbonoApartado.Result>> spGetAbonoApartado(spGetAbonoApartado.Request PostModel);
		Task<IEnumerable<spGetApartado.Result>> spGetApartado(spGetApartado.Request PostModel);
		Task<IEnumerable<spGetApartadoDetalle.Result>> spGetApartadoDetalle(spGetApartadoDetalle.Request PostModel);
		Task<IEnumerable<spGetArticulo.Result>> spGetArticulo(spGetArticulo.Request PostModel);
		Task<IEnumerable<spGetInventario.Result>> spGetInventario(spGetInventario.Request PostModel);
		Task<IEnumerable<spGetPedido.Result>> spGetPedido(spGetPedido.Request PostModel);
		Task<IEnumerable<spGetPedidoDetalle.Result>> spGetPedidoDetalle(spGetPedidoDetalle.Request PostModel);
		Task<IEnumerable<spGetProveedor.Result>> spGetProveedor(spGetProveedor.Request PostModel);
		Task<IEnumerable<spGetVenta.Result>> spGetVenta(spGetVenta.Request PostModel);
		Task<spSaveAbonoApartado.Result> spSaveAbonoApartado(spSaveAbonoApartado.Request PostModel);
		Task<spSaveApartado.Result> spSaveApartado(spSaveApartado.Request PostModel);
		Task<spSaveArticulo.Result> spSaveArticulo(spSaveArticulo.Request PostModel);
		Task<spSavePedido.Result> spSavePedido(spSavePedido.Request PostModel);
		Task<spSavePedidoDetalle.Result> spSavePedidoDetalle(spSavePedidoDetalle.Request PostModel);
		Task<spSaveProveedor.Result> spSaveProveedor(spSaveProveedor.Request PostModel);
		Task<spSaveVenta.Result> spSaveVenta(spSaveVenta.Request PostModel);
	}
}
