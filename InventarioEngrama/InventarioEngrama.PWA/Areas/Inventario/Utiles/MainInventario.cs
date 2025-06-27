using EngramaCoreStandar.Dapper.Results;
using EngramaCoreStandar.Mapper;
using EngramaCoreStandar.Results;
using EngramaCoreStandar.Servicios;

using InventarioEngrama.Share.Objetos.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

namespace InventarioEngrama.PWA.Areas.Inventario.Utiles
{
	public class MainInventario
	{

		private string url = @"api/Inventario";

		private readonly IHttpService _httpService;
		private readonly MapperHelper _mapper;
		private readonly IValidaServicioService _validaServicioService;

		public Proveedor ProveedorSelected { get; set; }
		public IList<Proveedor> LstProveedores { get; set; }
		public Articulo ArticuloSelected { get; set; }
		public IList<Articulo> LstArticulos { get; set; }

		public MainInventario(IHttpService httpService, MapperHelper mapper, IValidaServicioService validaServicioService)
		{
			_httpService = httpService;
			_mapper = mapper;
			_validaServicioService = validaServicioService;

			ProveedorSelected = new Proveedor();
			LstProveedores = new List<Proveedor>();

			ArticuloSelected = new Articulo();
			LstArticulos = new List<Articulo>();


		}


		public async Task<SeverityMessage> PostSaveArticulo()
		{
			var APIUrl = url + "/PostSaveArticulo";
			var model = _mapper.Get<Articulo, PostSaveArticulo>(ArticuloSelected);
			var response = await _httpService.Post<PostSaveArticulo, Response<Articulo>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstArticulos.Add(data));
			return validacion;

		}

		public async Task<SeverityMessage> PostGetArticulo()
		{
			var APIUrl = url + "/PostGetArticulo";

			var model = _mapper.Get<Articulo, PostGetArticulo>(ArticuloSelected);
			var response = await _httpService.Post<PostGetArticulo, Response<List<Articulo>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstArticulos = data);
			return validacion;
		}

		public async Task<SeverityMessage> PostSaveProveedor()
		{
			var APIUrl = url + "/PostSaveProveedor";
			var model = _mapper.Get<Proveedor, PostSaveProveedor>(ProveedorSelected);
			var response = await _httpService.Post<PostSaveProveedor, Response<Proveedor>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstProveedores.Add(data));
			return validacion;

		}
		public async Task<SeverityMessage> PostGetProveedor()
		{
			var APIUrl = url + "/PostGetProveedor";

			var model = _mapper.Get<Proveedor, PostGetProveedor>(ProveedorSelected);
			var response = await _httpService.Post<PostGetProveedor, Response<List<Proveedor>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstProveedores = data);
			return validacion;
		}

	}
}
