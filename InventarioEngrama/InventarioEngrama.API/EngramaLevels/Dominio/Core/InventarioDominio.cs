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

	}
}
