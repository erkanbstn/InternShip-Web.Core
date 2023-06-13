using InternShip.Core.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureService(builder.Configuration);



var app = builder.Build();
app.ConfigureApp();
