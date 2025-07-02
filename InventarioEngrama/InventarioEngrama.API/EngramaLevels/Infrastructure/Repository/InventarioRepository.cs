using EngramaCoreStandar.Dapper;
using EngramaCoreStandar.Extensions;

using InventarioEngrama.API.EngramaLevels.Infrastructure.Interfaces;
using InventarioEngrama.Share.Entity.Inventario;

namespace InventarioEngrama.API.EngramaLevels.Infrastructure.Repository
{
	public class InventarioRepository : IInventarioRepository
	{
		private readonly IDapperManagerHelper _managerHelper;

		public InventarioRepository(IDapperManagerHelper managerHelper)
		{
			this._managerHelper = managerHelper;
		}

		public async Task<spSaveArticulo.Result> spSaveArticulo(spSaveArticulo.Request PostModel)
		{
			var result = await _managerHelper.GetAsync<spSaveArticulo.Result, spSaveArticulo.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}
		public async Task<IEnumerable<spGetArticulo.Result>> spGetArticulo(spGetArticulo.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetArticulo.Result, spGetArticulo.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetArticulo.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}
		public async Task<spSaveProveedor.Result> spSaveProveedor(spSaveProveedor.Request PostModel)
		{
			var result = await _managerHelper.GetAsync<spSaveProveedor.Result, spSaveProveedor.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}
		public async Task<IEnumerable<spGetProveedor.Result>> spGetProveedor(spGetProveedor.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetProveedor.Result, spGetProveedor.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetProveedor.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}


		public async Task<spSavePedido.Result> spSavePedido(spSavePedido.Request PostModel)
		{
			var result = await _managerHelper.GetAsync<spSavePedido.Result, spSavePedido.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}


		public async Task<spSavePedidoDetalle.Result> spSavePedidoDetalle(spSavePedidoDetalle.Request PostModel)
		{
			var result = await _managerHelper.GetAsync<spSavePedidoDetalle.Result, spSavePedidoDetalle.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}

		public async Task<IEnumerable<spGetPedidoDetalle.Result>> spGetPedidoDetalle(spGetPedidoDetalle.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetPedidoDetalle.Result, spGetPedidoDetalle.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetPedidoDetalle.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}



		public async Task<IEnumerable<spGetPedido.Result>> spGetPedido(spGetPedido.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetPedido.Result, spGetPedido.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetPedido.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}

	}
}
