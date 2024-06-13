using DBAccess;
using DBAccess.DBControllers;
using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependency Injection Services
builder.Services.AddTransient<IDBCardAccess, DBCardAccess>();
builder.Services.AddTransient<IAvailableCardsController, AvailableCardsController>();
builder.Services.AddTransient<IAPIGetHandlers, APIGetHandlers>();
builder.Services.AddTransient<IAPIPostHandlers, APIPostHandlers>();

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
