using Security_Door_App.Logic.Interface;
using Security_Door_App.Logic.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;





var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.Run();
