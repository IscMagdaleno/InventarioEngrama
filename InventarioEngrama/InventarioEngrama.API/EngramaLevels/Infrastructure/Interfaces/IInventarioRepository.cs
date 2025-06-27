using InventarioEngrama.Share.Entity.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

namespace InventarioEngrama.API.EngramaLevels.Infrastructure.Interfaces
{
	public interface IInventarioRepository
	{
		Task<IEnumerable<spGetArticulo.Result>> spGetArticulo(spGetArticulo.Request PostModel);
		Task<IEnumerable<spGetProveedor.Result>> spGetProveedor(spGetProveedor.Request PostModel);
		Task<spSaveArticulo.Result> spSaveArticulo(spSaveArticulo.Request PostModel);
		Task<spSaveProveedor.Result> spSaveProveedor(spSaveProveedor.Request PostModel);
	}
}
