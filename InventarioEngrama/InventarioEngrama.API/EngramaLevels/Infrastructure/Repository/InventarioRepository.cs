﻿using EngramaCoreStandar.Dapper;
using EngramaCoreStandar.Extensions;

using InventarioEngrama.API.EngramaLevels.Infrastructure.Interfaces;
using InventarioEngrama.Share.Entity.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

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

		public async Task<IEnumerable<spGetInventario.Result>> spGetInventario(spGetInventario.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetInventario.Result, spGetInventario.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetInventario.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}



		public async Task<spSaveVenta.Result> spSaveVenta(spSaveVenta.Request PostModel)
		{
			var result = await _managerHelper.GetAsync<spSaveVenta.Result, spSaveVenta.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}

		public async Task<IEnumerable<spGetVenta.Result>> spGetVenta(spGetVenta.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetVenta.Result, spGetVenta.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetVenta.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}

		public async Task<spSaveApartado.Result> spSaveApartado(spSaveApartado.Request PostModel)
		{
			var result = await _managerHelper.GetWithListAsync<spSaveApartado.Result, spSaveApartado.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}


		public async Task<IEnumerable<spGetApartado.Result>> spGetApartado(spGetApartado.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetApartado.Result, spGetApartado.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetApartado.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}

		public async Task<spSaveAbonoApartado.Result> spSaveAbonoApartado(spSaveAbonoApartado.Request PostModel)
		{
			var result = await _managerHelper.GetAsync<spSaveAbonoApartado.Result, spSaveAbonoApartado.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}

		public async Task<IEnumerable<spGetAbonoApartado.Result>> spGetAbonoApartado(spGetAbonoApartado.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetAbonoApartado.Result, spGetAbonoApartado.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetAbonoApartado.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}

		public async Task<IEnumerable<spGetApartadoDetalle.Result>> spGetApartadoDetalle(spGetApartadoDetalle.Request PostModel)
		{
			var result = await _managerHelper.GetAllAsync<spGetApartadoDetalle.Result, spGetApartadoDetalle.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new List<spGetApartadoDetalle.Result>() { new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" } };
		}

		public async Task<spDeletePedidoDetalle.Result> spDeletePedidoDetalle(spDeletePedidoDetalle.Request PostModel)
		{
			var result = await _managerHelper.GetAsync<spDeletePedidoDetalle.Result, spDeletePedidoDetalle.Request>(PostModel);
			if (result.Ok)
			{
				return result.Data;
			}
			return new() { bResult = false, vchMessage = $"[{(result.Ex.NotNull() ? result.Ex.Message : "")}] - [{result.Msg}]" };
		}

	}
}
