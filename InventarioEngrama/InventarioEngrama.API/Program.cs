using EngramaCoreStandar.Extensions;

using InventarioEngrama.API.EngramaLevels.Dominio.Core;
using InventarioEngrama.API.EngramaLevels.Dominio.Interfaces;
using InventarioEngrama.API.EngramaLevels.Infrastructure.Interfaces;
using InventarioEngrama.API.EngramaLevels.Infrastructure.Repository;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<ITestDominio, TestDominio>();
builder.Services.AddScoped<IInventarioDominio, InventarioDominio>();

builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();

// Ensure the AddEngramaDependenciesAPI method is defined in the above namespace
builder.Services.AddEngramaDependenciesAPI();



/*Swagger configuration*/
builder.Services.AddSwaggerGen(options =>
{
	// using System.Reflection;
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var path = Path.Combine(AppContext.BaseDirectory, xmlFilename);
	options.IncludeXmlComments(path);

});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(x => x
					.AllowAnyMethod()
					.AllowAnyHeader()
					.SetIsOriginAllowed(origin => true) // allow any origin
					.AllowCredentials());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
