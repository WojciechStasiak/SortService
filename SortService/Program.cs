using SortService.Services;
using SortService.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ISortService, SortingService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();

// this needs to be to make it possible to see the SortService by the SortServiceTest
public partial class Program { }
