using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Security_Door_App.API.Account;
using Security_Door_App.API.Services;
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
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

//Config MailKit
var mailKitOptions = builder.Configuration.GetSection("MailSettings").Get<MailKitOptions>();
builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        Server = mailKitOptions.Server,
        Port = mailKitOptions.Port,
        SenderName = mailKitOptions.SenderName,
        SenderEmail = mailKitOptions.SenderEmail,
        Account = mailKitOptions.Account,
        Password = mailKitOptions.Password,
        Security = true
    });
});

builder.Services.AddTransient<ICard, CardRepository>();
builder.Services.AddTransient<IDoor, DoorRepository>();
builder.Services.AddTransient<IDoorReader, DoorReaderRepository>();
builder.Services.AddTransient<IDoorAction, DoorActionRepository>();
builder.Services.AddTransient<IEmail, EmailService>();
builder.Services.AddTransient<IUser,UserRepository>();
builder.Services.AddTransient<ICurrentUser, CurrentUser>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
