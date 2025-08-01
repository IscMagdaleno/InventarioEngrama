﻿using EngramaCoreStandar.Dapper.Results;
using EngramaCoreStandar.Mapper;
using EngramaCoreStandar.Results;
using EngramaCoreStandar.Servicios;

using InventarioEngrama.Share.Objetos;
using InventarioEngrama.Share.PostClass;

namespace InventarioEngrama.PWA.Areas.TestModul.Utiles
{
	public class DataTest
	{

		private string url = @"api/Test";

		private readonly IHttpService _httpService;
		private readonly MapperHelper mapperHelper;
		private readonly IValidaServicioService validaServicioService;

		public IList<Test_Table> LstTestTable { get; set; }

		public DataTest(IHttpService httpService, MapperHelper mapperHelper, IValidaServicioService validaServicioService)
		{
			_httpService = httpService;
			this.mapperHelper = mapperHelper;
			this.validaServicioService = validaServicioService;
			LstTestTable = new List<Test_Table>();
		}

		public async Task<SeverityMessage> PostTestTable()
		{
			var APIUrl = url + "/PostTestTable";

			var model = new PostTestTable();

			var response = await _httpService.Post<PostTestTable, Response<List<Test_Table>>>(APIUrl, model);
			var validacion = validaServicioService.ValidadionServicio(response,
				onSuccess: data => LstTestTable = data.ToList());


			return validacion;
		}


	}
}
