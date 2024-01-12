using ppedv.DiePizzaBude.Logic.Core;
using ppedv.DiePizzaBude.Model.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string conString = "Server=(localdb)\\mssqllocaldb;Database=DiePizzaBude_dev;Trusted_Connection=true;";
builder.Services.AddScoped<IRepository>(x => new ppedv.DiePizzaBude.Data.EfCore.PizzaEfContextRepositoryAdapter(conString));
builder.Services.AddScoped<IOrderServices, OrderServices>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
