﻿using EngramaCoreStandar.Dapper.Results;
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


		public Apartado ApartadoSelected { get; set; }
		public IList<Apartado> LstApartado { get; set; }


		public AbonoApartado AbonoApartadoSelected { get; set; }
		public IList<AbonoApartado> LstAbonoApartados { get; set; }

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

			ApartadoSelected = new Apartado();
			LstApartado = new List<Apartado>();

			AbonoApartadoSelected = new AbonoApartado();
			LstAbonoApartados = new List<AbonoApartado>();
		}


		public async Task<SeverityMessage> PostSaveArticulo()
		{
			ArticuloSelected.iIdProveedor = ArticuloSelected.Proveedor.iIdProveedor;
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
				ArticuloSelected.iIdArticulo = data.iIdArticulo;
				LstArticulos.Add(data);
			}


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
			PedidoDetalleSelected.mPrecioUnitario = PedidoDetalleSelected.Articulo.mPrecioCompra;

			PedidoDetalleSelected.iIdPedido = PedidoSelected.iIdPedido;
			PedidoDetalleSelected.iIdArticulo = PedidoDetalleSelected.Articulo.iIdArticulo;
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

		public void PostSaveVentaLocal()
		{
			VentaSelected.iIdArticulo = ArticuloSelected.iIdArticulo;
			VentaSelected.Articulo = ArticuloSelected;
			VentaSelected.dtFechaVenta = DateTime.UtcNow;

			var APIUrl = url + "/PostSaveVenta";
			var model = _mapper.Get<Venta, PostSaveVenta>(VentaSelected);


		}

		public async Task<SeverityMessage> PostSaveVenta()
		{

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

			LstVentas = LstVentas.OrderByDescending(e => e.dtFechaVenta).ToList();
			VentaSelected = new Venta();
			ArticuloSelected = new Articulo();
		}

		public async Task<SeverityMessage> PostGetVenta()
		{
			var APIUrl = url + "/PostGetVenta";

			var model = _mapper.Get<Venta, PostGetVenta>(VentaSelected);
			var response = await _httpService.Post<PostGetVenta, Response<List<Venta>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterGetVenta(data));
			return validacion;
		}

		private void AfterGetVenta(List<Venta> data)
		{

			LstVentas = data.OrderByDescending(e => e.dtFechaVenta).ToList();

		}


		public async Task<SeverityMessage> PostGetApartado()
		{
			var APIUrl = url + "/PostGetApartado";

			var model = _mapper.Get<Apartado, PostGetApartado>(ApartadoSelected);
			var response = await _httpService.Post<PostGetApartado, Response<List<Apartado>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstApartado = data);
			return validacion;
		}


		public void AddArticuloToApartado()
		{
			if (ApartadoSelected.ArticulosApartados == null)
			{
				ApartadoSelected.ArticulosApartados = new List<ArticulosApartados>();
			}
			var apartadoArticulo = new ArticulosApartados
			{
				iIdApartado = ApartadoSelected.iIdApartado,
				iIdArticulo = ArticuloSelected.iIdArticulo,
				mPrecioFinal = VentaSelected.mPrecioFinal,
				iCantidad = VentaSelected.iCantidad,
				Articulo = ArticuloSelected,
				vchReferenciaVenta = VentaSelected.vchReferenciaVenta
			};
			ApartadoSelected.ArticulosApartados.Add(apartadoArticulo);
			ApartadoSelected.mTotal += VentaSelected.mPrecioFinal;
			ArticuloSelected = new Articulo();
			VentaSelected = new Venta();
		}

		public async Task<SeverityMessage> PostSaveApartado()
		{
			var APIUrl = url + "/PostSaveApartado";

			var model = _mapper.Get<Apartado, PostSaveApartado>(ApartadoSelected);
			var response = await _httpService.Post<PostSaveApartado, Response<Apartado>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterSaveApartado(data), ContinueWarning: false);

			return validacion;
		}

		private void AfterSaveApartado(Apartado data)
		{


			ApartadoSelected.iIdApartado = data.iIdApartado;
			LstApartado.Add(ApartadoSelected);


		}

		public async Task<SeverityMessage> PostSaveAbonoApartado()
		{
			AbonoApartadoSelected.iIdApartado = ApartadoSelected.iIdApartado;
			AbonoApartadoSelected.dtFechaAbono = DateTime.UtcNow;
			var APIUrl = url + "/PostSaveAbonoApartado";
			var model = _mapper.Get<AbonoApartado, PostSaveAbonoApartado>(AbonoApartadoSelected);
			var response = await _httpService.Post<PostSaveAbonoApartado, Response<AbonoApartado>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => AfterSaveAbonoApartado(data));
			return validacion;

		}


		private void AfterSaveAbonoApartado(AbonoApartado data)
		{
			LstAbonoApartados.Add(data);


			ApartadoSelected.mTotal -= AbonoApartadoSelected.mAbono;

			if (ApartadoSelected.mTotal <= 0)
			{
				ApartadoSelected.bPagado = true;
			}
		}

		public async Task<SeverityMessage> PostGetAbonoApartado()
		{
			var APIUrl = url + "/PostGetAbonoApartado";

			var model = _mapper.Get<Apartado, PostGetAbonoApartado>(ApartadoSelected);
			var response = await _httpService.Post<PostGetAbonoApartado, Response<List<AbonoApartado>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => LstAbonoApartados = data);
			return validacion;
		}

		public async Task<SeverityMessage> PostGetArticulosApartados()
		{
			var APIUrl = url + "/PostGetApartadoDetalle";

			var model = _mapper.Get<Apartado, PostGetApartadoDetalle>(ApartadoSelected);
			var response = await _httpService.Post<PostGetApartadoDetalle, Response<List<ArticulosApartados>>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response,
			onSuccess: data => ApartadoSelected.ArticulosApartados = data);
			return validacion;
		}


		public async Task<SeverityMessage> PostDeletePedidoDetalle()
		{
			var APIUrl = url + "/PostDeletePedidoDetalle";
			var model = _mapper.Get<PedidoDetalle, PostDeletePedidoDetalle>(PedidoDetalleSelected);
			var response = await _httpService.Post<PostDeletePedidoDetalle, Response<GenericResponse>>(APIUrl, model);
			var validacion = _validaServicioService.ValidadionServicio(response);
			return validacion;

		}



	}
}
