using EgiitmwebapiIzuBtk.DataContext;
using EgiitmwebapiIzuBtk.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
// context s�n�f�                                                                                                //appsettings.json dosyas�dan gelen SqlServer
builder.Services.AddDbContext<ApplicationDbContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));  // repositoryleri servis kayd� yapt�k di ettik
var app = builder.Build();

// Configure the HTTP request pipeline.
// geli�tirme ortam�nda gozukecek sayfa
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
