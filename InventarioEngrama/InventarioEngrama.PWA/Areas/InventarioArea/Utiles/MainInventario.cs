using EngramaCoreStandar.Dapper.Results;
using EngramaCoreStandar.Mapper;
using EngramaCoreStandar.Results;
using EngramaCoreStandar.Servicios;

using InventarioEngrama.Share.Objetos.Inventario;
using InventarioEngrama.Share.PostClass.Inventario;

namespace InventarioEngrama.PWA.Areas.InventarioArea.Utiles
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


		public IList<InventarioArticulos> LstArticulosInventario { get; set; }

		public Venta VentaSelected { get; set; }
		public IList<Venta> LstVentas { get; set; }

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

			LstArticulosInventario = new List<InventarioArticulos>();

			VentaSelected = new Venta();
			LstVentas = new List<Venta>();
		}


		public async Task<SeverityMessage> PostSaveArticulo()
		{
			ArticuloSelected.iIdProveedor = ProveedorSelected.iIdProveedor;
			var APIUrl = url + "/PostSaveArticulo";
			var model = _mapper.Get<Articulo, PostSaveArticulo>(ArticuloSelected);
			var response = await _httpService.Post<PostSaveArticulo, Response<Articulo>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterSaveArticulo(data));
			return validacion;

		}
		private void AfterSaveArticulo(Articulo data)
		{
			if (ArticuloSelected.iIdArticulo <= 0)
			{
				LstArticulos.Add(data);
			}

			ArticuloSelected = new Articulo();

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

		public void FilterArticuloByProvedor()
		{
			LstArticulos = LstArticulos.Where(e => e.iIdProveedor == ProveedorSelected.iIdProveedor).ToList();

		}

		public async Task<SeverityMessage> PostSaveProveedor()
		{
			var APIUrl = url + "/PostSaveProveedor";
			var model = _mapper.Get<Proveedor, PostSaveProveedor>(ProveedorSelected);
			var response = await _httpService.Post<PostSaveProveedor, Response<Proveedor>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterSaveProveedor(data));
			return validacion;

		}

		private void AfterSaveProveedor(Proveedor data)
		{
			if (ProveedorSelected.iIdProveedor <= 0)
			{
				LstProveedores.Add(data);
			}

			ProveedorSelected = new Proveedor();
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
			PedidoSelected.iIdProveedor = ProveedorSelected.iIdProveedor;
			var model = _mapper.Get<Pedido, PostSavePedido>(PedidoSelected);
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
			PedidoDetalleSelected.mPrecioUnitario = ArticuloSelected.mPrecioCompra;
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
			if (PedidoDetalleSelected.iIdPedidoDetalle <= 0)
			{
				PedidoDetalleSelected.iIdPedidoDetalle = data.iIdPedidoDetalle;
				LstPedidosDetalle.Add(PedidoDetalleSelected);
			}


			ArticuloSelected = new Articulo();
			PedidoDetalleSelected = new PedidoDetalle();
		}


		public async Task<SeverityMessage> PostGetPedidoDetalle()
		{
			var APIUrl = url + "/PostGetPedidoDetalle";
			var model = _mapper.Get<Pedido, PostGetPedidoDetalle>(PedidoSelected);
			var response = await _httpService.Post<PostGetPedidoDetalle, Response<List<PedidoDetalle>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstPedidosDetalle = (data));
			return validacion;

		}

		public async Task<SeverityMessage> PostGetPedido()
		{
			var APIUrl = url + "/PostGetPedido";

			var model = _mapper.Get<Pedido, PostGetPedido>(PedidoSelected);
			var response = await _httpService.Post<PostGetPedido, Response<List<Pedido>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstPedidos = data);
			return validacion;
		}

		public async Task<SeverityMessage> PostGetInventario()
		{
			var APIUrl = url + "/PostGetInventario";

			var model = new PostGetInventario();
			var response = await _httpService.Post<PostGetInventario, Response<List<InventarioArticulos>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstArticulosInventario = data);
			return validacion;
		}


		public async Task<SeverityMessage> PostSaveVenta()
		{
			VentaSelected.iIdArticulo = ArticuloSelected.iIdArticulo;
			VentaSelected.Articulo = ArticuloSelected;

			var APIUrl = url + "/PostSaveVenta";
			var model = _mapper.Get<Venta, PostSaveVenta>(VentaSelected);
			var response = await _httpService.Post<PostSaveVenta, Response<Venta>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterSaveVenta(data));
			return validacion;

		}

		private void AfterSaveVenta(Venta data)
		{
			VentaSelected.iIdVenta = data.iIdVenta;
			LstVentas.Add(VentaSelected);
			VentaSelected = new Venta();
			ArticuloSelected = new Articulo();
		}

		public async Task<SeverityMessage> PostGetVenta()
		{
			var APIUrl = url + "/PostGetVenta";

			var model = _mapper.Get<Venta, PostGetVenta>(VentaSelected);
			var response = await _httpService.Post<PostGetVenta, Response<List<Venta>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstVentas = (data));
			return validacion;
		}


	}
}
