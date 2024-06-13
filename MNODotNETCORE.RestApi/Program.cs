using Microsoft.EntityFrameworkCore;
using MNODotNetCore.shared;
using MNODotNETCORE.RestApi.Databases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
}, 
ServiceLifetime.Transient,
ServiceLifetime.Transient);

/*builder.Services.AddScoped<AdoDotNetServices>(n => new AdoDotNetServices(connectionString));
builder.Services.AddScoped<DapperServices>(n => new DapperServices(connectionString));*/

builder.Services.AddScoped(n => new AdoDotNetServices(connectionString));
builder.Services.AddScoped(n => new DapperServices(connectionString));

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
