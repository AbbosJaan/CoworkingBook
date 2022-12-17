using DataAccess;
using DataAccess.Repositorys;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CoworkingBookingDb")));
builder.Services.AddTransient<IGenericCRUDService<BranchModel>, MockService>();
builder.Services.AddTransient<IGenericRepository<BranchModel>, BranchesRepository>();
//for check
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
