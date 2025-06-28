using InventarioEngrama.Share.Entity.Inventario;

namespace InventarioEngrama.API.EngramaLevels.Infrastructure.Interfaces
{
	public interface IInventarioRepository
	{
		Task<IEnumerable<spGetArticulo.Result>> spGetArticulo(spGetArticulo.Request PostModel);
		Task<IEnumerable<spGetPedidoDetalle.Result>> spGetPedidoDetalle(spGetPedidoDetalle.Request PostModel);
		Task<IEnumerable<spGetProveedor.Result>> spGetProveedor(spGetProveedor.Request PostModel);
		Task<spSaveArticulo.Result> spSaveArticulo(spSaveArticulo.Request PostModel);
		Task<spSavePedido.Result> spSavePedido(spSavePedido.Request PostModel);
		Task<spSavePedidoDetalle.Result> spSavePedidoDetalle(spSavePedidoDetalle.Request PostModel);
		Task<spSaveProveedor.Result> spSaveProveedor(spSaveProveedor.Request PostModel);
	}
}
