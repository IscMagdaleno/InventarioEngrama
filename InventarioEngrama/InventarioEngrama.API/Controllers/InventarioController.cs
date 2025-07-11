using InventarioEngrama.API.EngramaLevels.Dominio.Interfaces;
using InventarioEngrama.Share.Objetos.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

using Microsoft.AspNetCore.Mvc;

namespace InventarioEngrama.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InventarioController : ControllerBase
	{
		private readonly IInventarioDominio inventarioDominio;

		public InventarioController(IInventarioDominio inventarioDominio)
		{
			this.inventarioDominio = inventarioDominio;
		}


		/// <summary>
		/// Guardar los Articulos en la base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostSaveArticulo")]
		public async Task<IActionResult> PostSaveArticulo([FromBody] PostSaveArticulo postModel)
		{
			var result = await inventarioDominio.SaveArticulo(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Obtener los articulos de la base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetArticulo")]
		public async Task<IActionResult> PostGetArticulo([FromBody] PostGetArticulo postModel)
		{
			var result = await inventarioDominio.GetArticulo(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		/// <summary>
		/// Guardar provedores en base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostSaveProveedor")]
		public async Task<IActionResult> PostSaveProveedor([FromBody] PostSaveProveedor postModel)
		{
			var result = await inventarioDominio.SaveProveedor(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		/// <summary>
		/// Obtener los provedores de la base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetProveedor")]
		public async Task<IActionResult> PostGetProveedor([FromBody] PostGetProveedor postModel)
		{
			var result = await inventarioDominio.GetProveedor(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Guardar un pedido en la base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostSavePedido")]
		public async Task<IActionResult> PostSavePedido([FromBody] PostSavePedido postModel)
		{
			var result = await inventarioDominio.SavePedido(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		/// <summary>
		/// Agregar un detalle de pedido a la base de datos
		/// 
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostSavePedidoDetalle")]
		public async Task<IActionResult> PostSavePedidoDetalle([FromBody] PostSavePedidoDetalle postModel)
		{
			var result = await inventarioDominio.SavePedidoDetalle(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		/// <summary>
		/// Retona el detalle de un pedido con todos los articulos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetPedidoDetalle")]
		public async Task<IActionResult> PostGetPedidoDetalle([FromBody] PostGetPedidoDetalle postModel)
		{
			var result = await inventarioDominio.GetPedidoDetalle(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Obtener todos los pedidos de la base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetPedido")]
		public async Task<IActionResult> PostGetPedido([FromBody] PostGetPedido postModel)
		{
			var result = await inventarioDominio.GetPedido(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Consulta los articulos con existencia en el inventario
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetInventario")]
		public async Task<IActionResult> PostGetInventario([FromBody] PostGetInventario postModel)
		{
			var result = await inventarioDominio.GetInventario(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Guarda las ventas realizadas o las salidas de mercancias del inventario
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostSaveVenta")]
		public async Task<IActionResult> PostSaveVenta([FromBody] PostSaveVenta postModel)
		{
			var result = await inventarioDominio.SaveVenta(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Consulta las ventas realizadas por medio de la aplicacion
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetVenta")]
		public async Task<IActionResult> PostGetVenta([FromBody] PostGetVenta postModel)
		{
			var result = await inventarioDominio.GetVenta(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

	}
}
