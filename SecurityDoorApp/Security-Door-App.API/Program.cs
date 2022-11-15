using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Security_Door_App.Data.Contexts;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.Interface;
using Security_Door_App.Logic.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
       c =>
       {
           c.SwaggerDoc("v1", new OpenApiInfo
           {
               Title = "Secure.SecurityDoors.Api",
               Version = "v1"
           });
       });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();


builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddTransient<ICard, CardRepository>();
builder.Services.AddTransient<IDoor, DoorRepository>();
builder.Services.AddTransient<IDoorReader, DoorReaderRepository>();
builder.Services.AddTransient<IDoorAction, DoorActionRepository>();

builder.Services.AddAutoMapper(
    Assembly.Load("Security-Door-App.Logic"));



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
