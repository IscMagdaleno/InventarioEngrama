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


		public Pedido PedidoSelected { get; set; }
		public PedidoDetalle PedidoDetalleSelected { get; set; }
		public IList<Pedido> LstPedidos { get; set; }
		public IList<PedidoDetalle> LstPedidosDetalle { get; set; }

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

			PedidoSelected = new Pedido();
			PedidoDetalleSelected = new PedidoDetalle();
			LstPedidos = new List<Pedido>();
			LstPedidosDetalle = new List<PedidoDetalle>();
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



		public async Task<SeverityMessage> PostSavePedido()
		{
			var APIUrl = url + "/PostSavePedido";
			var model = _mapper.Get<Proveedor, PostSavePedido>(ProveedorSelected);
			var response = await _httpService.Post<PostSavePedido, Response<Pedido>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterSavePedido(data));
			return validacion;

		}

		private void AfterSavePedido(Pedido data)
		{
			PedidoSelected = data;
			LstPedidos.Add(data);
		}


		public async Task<SeverityMessage> PostSavePedidoDetalle()
		{
			PedidoDetalleSelected.iIdPedido = PedidoSelected.iIdPedido;
			PedidoDetalleSelected.iIdArticulo = ArticuloSelected.iIdArticulo;
			PedidoDetalleSelected.Articulo = ArticuloSelected;
			PedidoSelected.Proveedor = ProveedorSelected;

			var APIUrl = url + "/PostSavePedidoDetalle";
			var model = _mapper.Get<PedidoDetalle, PostSavePedidoDetalle>(PedidoDetalleSelected);

			model.iIdProveedor = PedidoSelected.Proveedor.iIdProveedor;

			var response = await _httpService.Post<PostSavePedidoDetalle, Response<PedidoDetalle>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterSavePedidoDetalle(data));


			return validacion;

		}

		private void AfterSavePedidoDetalle(PedidoDetalle data)
		{
			PedidoDetalleSelected.iIdPedidoDetalle = data.iIdPedidoDetalle;
			LstPedidosDetalle.Add(PedidoDetalleSelected);

			ArticuloSelected = new Articulo();
			PedidoDetalleSelected = new PedidoDetalle();
		}


		public async Task<SeverityMessage> PostGetPedidoDetalle()
		{
			var APIUrl = url + "/PostGetPedidoDetalle";
			var model = _mapper.Get<Pedido, PostGetPedidoDetalle>(PedidoSelected);
			var response = await _httpService.Post<PostGetPedidoDetalle, Response<PedidoDetalle>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstPedidosDetalle.Add(data));
			return validacion;

		}

	}
}
