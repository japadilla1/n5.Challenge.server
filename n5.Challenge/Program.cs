using Microsoft.EntityFrameworkCore;
using n5.Challenge.Application.Repositories;
using n5.Challenge.Application.UnitOfWork;
using n5.Challenge.Infrastructure.Context;
using n5.Challenge.Infrastructure.Repositories;
using n5.Challenge.Infrastructure.UnitOfWork;
using Nest;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión desde appsettings.json
builder.Services.AddDbContext<PermissionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var endPoint = builder.Configuration.GetValue<string>("ElasticSearch:EndPoint");
var index = builder.Configuration.GetValue<string>("ElasticSearch:Index");
var connectionString = new ConnectionSettings(new Uri(endPoint)).BasicAuthentication("elastic","elastic").DefaultIndex(index);
var elastic = new ElasticClient(connectionString);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSingleton<IElasticClient>(elastic);
// Add services to the container.
builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();
builder.Services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(Assembly.Load("n5.Challenge.Application"));
});

builder.Services.AddAutoMapper(Assembly.Load("n5.Challenge.Infrastructure"));

// Configurar CORS para permitir solicitudes desde cualquier origen (ajustar según tus necesidades)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Activar CORS
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PermissionDbContext>();
    context.Database.Migrate();
};

app.Run();
