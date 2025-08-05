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
		/// Guardar los Artículos en la base de datos
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
		/// Obtener los artículos de la base de datos
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
		/// Guardar proveedores en base de datos
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
		/// Obtener los proveedores de la base de datos
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
		/// Retorna el detalle de un pedido con todos los artículos
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
		/// Consulta los artículos con existencia en el inventario
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
		/// Guarda las ventas realizadas o las salidas de mercancías del inventario
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
		/// Consulta las ventas realizadas por medio de la aplicación
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

		/// <summary>
		/// Guardar un producto Apartado
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostSaveApartado")]
		public async Task<IActionResult> PostSaveApartado([FromBody] PostSaveApartado postModel)
		{
			var result = await inventarioDominio.SaveApartado(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Consulta los ARticulos apartados de la base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetApartado")]
		public async Task<IActionResult> PostGetApartado([FromBody] PostGetApartado postModel)
		{
			var result = await inventarioDominio.GetApartado(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Guarda los abonos en la base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostSaveAbonoApartado")]
		public async Task<IActionResult> PostSaveAbonoApartado([FromBody] PostSaveAbonoApartado postModel)
		{
			var result = await inventarioDominio.SaveAbonoApartado(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Retorna los abonos realizados a los apartados
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetAbonoApartado")]
		public async Task<IActionResult> PostGetAbonoApartado([FromBody] PostGetAbonoApartado postModel)
		{
			var result = await inventarioDominio.GetAbonoApartado(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Obtiene los artículos apartados registrados el base de datos
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostGetApartadoDetalle")]
		public async Task<IActionResult> PostGetApartadoDetalle([FromBody] PostGetApartadoDetalle postModel)
		{
			var result = await inventarioDominio.GetApartadoDetalle(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		/// <summary>
		/// Elimina los artículos erróneos de un pedido
		/// </summary>
		/// <param name="postModel"></param>
		/// <returns></returns>
		[HttpPost("PostDeletePedidoDetalle")]
		public async Task<IActionResult> PostDeletePedidoDetalle([FromBody] PostDeletePedidoDetalle postModel)
		{
			var result = await inventarioDominio.DeletePedidoDetalle(postModel);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

	}
}
