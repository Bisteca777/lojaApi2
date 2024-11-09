
using LojaApi.Repository;
using ProdutosApi.Repositories;
using UsuarioApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the bank.

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Realiza a leitura da conexão com o banco

builder.Services.AddSingleton<ProdutosRepository>(provider => new ProdutosRepository(connectionString));
builder.Services.AddSingleton<PedidosRepository>(provider => new PedidosRepository(connectionString));
builder.Services.AddSingleton<UsuarioRepository>(provider => new UsuarioRepository(connectionString));


//Swagger Parte 1
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

//Swagger Parte 2
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crud Biblioteca V1");
        c.RoutePrefix = string.Empty;
    });
}
     
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();