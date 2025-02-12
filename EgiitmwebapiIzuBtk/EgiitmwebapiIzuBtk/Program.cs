using EgiitmwebapiIzuBtk.DataContext;
using EgiitmwebapiIzuBtk.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
// context sýnýfý                                                                                                //appsettings.json dosyasýdan gelen SqlServer
builder.Services.AddDbContext<ApplicationDbContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));  // repositoryleri servis kaydý yaptýk di ettik
var app = builder.Build();

// Configure the HTTP request pipeline.
// geliþtirme ortamýnda gozukecek sayfa
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
