using InventarioEngrama.API.EngramaLevels.Dominio.Interfaces;
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

	}
}
