using StorageAccounting.Application.Interfaces.Services.Arrival;
using StorageAccounting.Application.Profiles;
using StorageAccounting.Application.Services.Arrival;
using StorageAccounting.Common.Configurations;
using StorageAccounting.Domain.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbConnection>(builder.Configuration.GetSection(nameof(DbConnection)));
builder.Services.AddDbContext<StorageAccountingContext>();

builder.Services.AddScoped<IArrivalService, ArrivalService>();

builder.Services.AddAutoMapper(typeof(ApplicationProfile));

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
