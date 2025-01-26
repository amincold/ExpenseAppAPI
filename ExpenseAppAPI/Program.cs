using ExpenseAppAPI.Model;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddControllers();
builder.Services.AddDbContext<ExpenseAppContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
