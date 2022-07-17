using CDShopApp.Repositories;
using CDShopApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICDRepository>(s =>
    new CDRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ICDService, CDService>();

var app = builder.Build();

app.MapControllers();

app.Run();


