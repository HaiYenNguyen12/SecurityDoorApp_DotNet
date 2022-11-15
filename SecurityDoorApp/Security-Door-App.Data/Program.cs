using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Security_Door_App.Data.Contexts;
using Security_Door_App.Data.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();


var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
