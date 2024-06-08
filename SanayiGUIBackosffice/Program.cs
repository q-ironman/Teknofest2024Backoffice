using SanayiGUIWebApi.Middlewares;
using SanayiGUIWebApi.Utilites;
using System.Net.WebSockets;
using System.Text;
using WebSocketManager = SanayiGUIWebApi.Utilites.WebSocketManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IWebSocketManager,WebSocketManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000").
        AllowAnyHeader().
        AllowAnyMethod().
        AllowCredentials();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();
app.UseMiddleware<WebSocketMiddleware>();

app.Run();
