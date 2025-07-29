using EngramaCoreStandar.Dapper.Results;
using EngramaCoreStandar.Results;

using InventarioEngrama.Share.Objetos.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

namespace InventarioEngrama.API.EngramaLevels.Dominio.Interfaces
{
	public interface IInventarioDominio
	{
		Task<Response<GenericResponse>> DeletePedidoDetalle(PostDeletePedidoDetalle PostModel);
		Task<Response<IEnumerable<AbonoApartado>>> GetAbonoApartado(PostGetAbonoApartado PostModel);
		Task<Response<IEnumerable<Apartado>>> GetApartado(PostGetApartado PostModel);
		Task<Response<IEnumerable<ArticulosApartados>>> GetApartadoDetalle(PostGetApartadoDetalle PostModel);
		Task<Response<IEnumerable<Articulo>>> GetArticulo(PostGetArticulo PostModel);
		Task<Response<IEnumerable<InventarioArticulos>>> GetInventario(PostGetInventario PostModel);
		Task<Response<IEnumerable<Pedido>>> GetPedido(PostGetPedido PostModel);
		Task<Response<IEnumerable<PedidoDetalle>>> GetPedidoDetalle(PostGetPedidoDetalle PostModel);
		Task<Response<IEnumerable<Proveedor>>> GetProveedor(PostGetProveedor PostModel);
		Task<Response<IEnumerable<Venta>>> GetVenta(PostGetVenta PostModel);
		Task<Response<AbonoApartado>> SaveAbonoApartado(PostSaveAbonoApartado PostModel);
		Task<Response<Apartado>> SaveApartado(PostSaveApartado PostModel);
		Task<Response<Articulo>> SaveArticulo(PostSaveArticulo PostModel);
		Task<Response<Pedido>> SavePedido(PostSavePedido PostModel);
		Task<Response<PedidoDetalle>> SavePedidoDetalle(PostSavePedidoDetalle PostModel);
		Task<Response<Proveedor>> SaveProveedor(PostSaveProveedor PostModel);
		Task<Response<Venta>> SaveVenta(PostSaveVenta PostModel);
	}
}
