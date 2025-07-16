using EngramaCoreStandar.Mapper;
using EngramaCoreStandar.Results;

using InventarioEngrama.API.EngramaLevels.Dominio.Interfaces;
using InventarioEngrama.API.EngramaLevels.Infrastructure.Interfaces;
using InventarioEngrama.Share.Entity.Inventario;
using InventarioEngrama.Share.Objetos.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

namespace InventarioEngrama.API.EngramaLevels.Dominio.Core
{
	public class InventarioDominio : IInventarioDominio
	{
		private readonly IInventarioRepository inventarioRepository;
		private readonly MapperHelper mapperHelper;
		private readonly IResponseHelper responseHelper;

		public InventarioDominio(IInventarioRepository inventarioRepository,
		MapperHelper mapperHelper,
		IResponseHelper responseHelper)
		{
			this.inventarioRepository = inventarioRepository;
			this.mapperHelper = mapperHelper;
			this.responseHelper = responseHelper;
		}


		public async Task<Response<Articulo>> SaveArticulo(PostSaveArticulo PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostSaveArticulo, spSaveArticulo.Request>(PostModel);
				var result = await inventarioRepository.spSaveArticulo(model);
				var validation = responseHelper.Validacion<spSaveArticulo.Result, Articulo>(result);
				if (validation.IsSuccess)
				{
					PostModel.iIdArticulo = validation.Data.iIdArticulo;
					validation.Data = mapperHelper.Get<PostSaveArticulo, Articulo>(PostModel);
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<Articulo>.BadResult(ex.Message, new());
			}
		}

		public async Task<Response<IEnumerable<Articulo>>> GetArticulo(PostGetArticulo PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostGetArticulo, spGetArticulo.Request>(PostModel);
				var result = await inventarioRepository.spGetArticulo(model);
				var validation = responseHelper.Validacion<spGetArticulo.Result, Articulo>(result);
				if (validation.IsSuccess)
				{
					validation.Data = validation.Data;
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<IEnumerable<Articulo>>.BadResult(ex.Message, new List<Articulo>());
			}
		}

		public async Task<Response<Proveedor>> SaveProveedor(PostSaveProveedor PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostSaveProveedor, spSaveProveedor.Request>(PostModel);
				var result = await inventarioRepository.spSaveProveedor(model);
				var validation = responseHelper.Validacion<spSaveProveedor.Result, Proveedor>(result);
				if (validation.IsSuccess)
				{
					PostModel.iIdProveedor = validation.Data.iIdProveedor;
					validation.Data = mapperHelper.Get<PostSaveProveedor, Proveedor>(PostModel);
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<Proveedor>.BadResult(ex.Message, new());
			}
		}

		public async Task<Response<IEnumerable<Proveedor>>> GetProveedor(PostGetProveedor PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostGetProveedor, spGetProveedor.Request>(PostModel);
				var result = await inventarioRepository.spGetProveedor(model);
				var validation = responseHelper.Validacion<spGetProveedor.Result, Proveedor>(result);
				if (validation.IsSuccess)
				{
					validation.Data = validation.Data;
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<IEnumerable<Proveedor>>.BadResult(ex.Message, new List<Proveedor>());
			}
		}


		public async Task<Response<Pedido>> SavePedido(PostSavePedido PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostSavePedido, spSavePedido.Request>(PostModel);
				var result = await inventarioRepository.spSavePedido(model);
				var validation = responseHelper.Validacion<spSavePedido.Result, Pedido>(result);
				if (validation.IsSuccess)
				{
					var ID = validation.Data.iIdPedido;
					validation.Data = mapperHelper.Get<PostSavePedido, Pedido>(PostModel);
					validation.Data.iIdPedido = ID;
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<Pedido>.BadResult(ex.Message, new());
			}
		}

		public async Task<Response<PedidoDetalle>> SavePedidoDetalle(PostSavePedidoDetalle PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostSavePedidoDetalle, spSavePedidoDetalle.Request>(PostModel);
				var result = await inventarioRepository.spSavePedidoDetalle(model);
				var validation = responseHelper.Validacion<spSavePedidoDetalle.Result, PedidoDetalle>(result);
				if (validation.IsSuccess)
				{
					var ID = validation.Data.iIdPedidoDetalle;
					validation.Data = mapperHelper.Get<PostSavePedidoDetalle, PedidoDetalle>(PostModel);
					validation.Data.iIdPedidoDetalle = ID;
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<PedidoDetalle>.BadResult(ex.Message, new());
			}
		}

		public async Task<Response<IEnumerable<PedidoDetalle>>> GetPedidoDetalle(PostGetPedidoDetalle PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostGetPedidoDetalle, spGetPedidoDetalle.Request>(PostModel);
				var result = await inventarioRepository.spGetPedidoDetalle(model);
				var validation = responseHelper.Validacion<spGetPedidoDetalle.Result, PedidoDetalle>(result);
				if (validation.IsSuccess)
				{

					foreach (var item in validation.Data)
					{
						item.Articulo = mapperHelper.Get<spGetPedidoDetalle.Result, Articulo>(result.FirstOrDefault(e => e.iIdPedidoDetalle == item.iIdPedidoDetalle));
					}
				}

				return validation;
			}
			catch (Exception ex)
			{
				return Response<IEnumerable<PedidoDetalle>>.BadResult(ex.Message, new List<PedidoDetalle>());
			}
		}

		public async Task<Response<IEnumerable<Pedido>>> GetPedido(PostGetPedido PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostGetPedido, spGetPedido.Request>(PostModel);
				var result = await inventarioRepository.spGetPedido(model);
				var validation = responseHelper.Validacion<spGetPedido.Result, Pedido>(result);
				if (validation.IsSuccess)
				{
					foreach (var item in validation.Data)
					{
						item.Proveedor = mapperHelper.Get<spGetPedido.Result, Proveedor>(result.FirstOrDefault(e => e.iIdPedido == item.iIdPedido));
					}
				}

				return validation;
			}
			catch (Exception ex)
			{
				return Response<IEnumerable<Pedido>>.BadResult(ex.Message, new List<Pedido>());
			}
		}


		public async Task<Response<IEnumerable<InventarioArticulos>>> GetInventario(PostGetInventario PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostGetInventario, spGetInventario.Request>(PostModel);
				var result = await inventarioRepository.spGetInventario(model);
				var validation = responseHelper.Validacion<spGetInventario.Result, InventarioArticulos>(result);
				if (validation.IsSuccess)
				{
					foreach (var item in validation.Data)
					{
						var row = result.FirstOrDefault(e => e.iIdInventario == item.iIdInventario);
						item.Articulo = mapperHelper.Get<spGetInventario.Result, Articulo>(row);
						item.Articulo.nvchNombre = row.nvchNombreArticulo;
						item.Articulo.Proveedor = mapperHelper.Get<spGetInventario.Result, Proveedor>(row);
						item.Articulo.Proveedor.nvchNombre = row.nvchNombreProveedor;
					}
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<IEnumerable<InventarioArticulos>>.BadResult(ex.Message, new List<InventarioArticulos>());
			}
		}


		public async Task<Response<Venta>> SaveVenta(PostSaveVenta PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostSaveVenta, spSaveVenta.Request>(PostModel);
				var result = await inventarioRepository.spSaveVenta(model);
				var validation = responseHelper.Validacion<spSaveVenta.Result, Venta>(result);
				if (validation.IsSuccess)
				{
					var iIdVenta = validation.Data.iIdVenta;
					validation.Data = mapperHelper.Get<PostSaveVenta, Venta>(PostModel);
					validation.Data.iIdVenta = iIdVenta;
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<Venta>.BadResult(ex.Message, new());
			}
		}


		public async Task<Response<IEnumerable<Venta>>> GetVenta(PostGetVenta PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostGetVenta, spGetVenta.Request>(PostModel);
				var result = await inventarioRepository.spGetVenta(model);
				var validation = responseHelper.Validacion<spGetVenta.Result, Venta>(result);
				if (validation.IsSuccess)
				{
					foreach (var item in validation.Data)
					{
						var row = result.FirstOrDefault(e => e.iIdVenta == item.iIdVenta);
						item.Articulo = mapperHelper.Get<spGetVenta.Result, Articulo>(row);
					}
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<IEnumerable<Venta>>.BadResult(ex.Message, new List<Venta>());
			}
		}


		public async Task<Response<Apartado>> SaveApartado(PostSaveApartado PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostSaveApartado, spSaveApartado.Request>(PostModel);
				List<DTApartadoDetalle> lista = new List<DTApartadoDetalle>();
				foreach (var item in PostModel.LstDetalles)
				{

					lista.Add(mapperHelper.Get<ApartadoDetalle, DTApartadoDetalle>(item));
				}
				model.Detalles = lista;

				var result = await inventarioRepository.spSaveApartado(model);
				var validation = responseHelper.Validacion<spSaveApartado.Result, Apartado>(result);
				if (validation.IsSuccess)
				{
					var id = validation.Data.iIdApartado;
					validation.Data = mapperHelper.Get<PostSaveApartado, Apartado>(PostModel);
					validation.Data.iIdApartado = id;
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<Apartado>.BadResult(ex.Message, new());
			}


		}

		public async Task<Response<IEnumerable<Apartado>>> GetApartado(PostGetApartado PostModel)
		{
			try
			{
				var model = mapperHelper.Get<PostGetApartado, spGetApartado.Request>(PostModel);
				var result = await inventarioRepository.spGetApartado(model);
				var validation = responseHelper.Validacion<spGetApartado.Result, Apartado>(result);
				if (validation.IsSuccess)
				{
					foreach (var item in validation.Data)
					{
						var lstDetalle = result.Where(e => e.iIdApartado == item.iIdApartado);
						foreach (var item1 in lstDetalle)
						{
							item.Detalles.Add(mapperHelper.Get<spGetApartado.Result, ApartadoDetalle>(item1));
						}
					}
				}
				return validation;
			}
			catch (Exception ex)
			{
				return Response<IEnumerable<Apartado>>.BadResult(ex.Message, new List<Apartado>());
			}
		}


	}
}
