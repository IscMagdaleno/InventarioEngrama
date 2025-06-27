using EngramaCoreStandar.Results;

using InventarioEngrama.Share.Objetos.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

namespace InventarioEngrama.API.EngramaLevels.Dominio.Interfaces
{
	public interface IInventarioDominio
	{
		Task<Response<IEnumerable<Articulo>>> GetArticulo(PostGetArticulo PostModel);
		Task<Response<IEnumerable<Proveedor>>> GetProveedor(PostGetProveedor PostModel);
		Task<Response<Articulo>> SaveArticulo(PostSaveArticulo PostModel);
		Task<Response<Proveedor>> SaveProveedor(PostSaveProveedor PostModel);
	}
}
