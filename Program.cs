using Microsoft.EntityFrameworkCore;
using mms_api.Domain.Bank;
using mms_api.Domain.Business;
using mms_api.Domain.Image;
using mms_api.Domain.Payment;
using mms_api.Infrastructure;
using mms_api.Infrastucture;
using mms_api.Managers.BankManager;
using mms_api.Managers.BusinessManager;
using mms_api.Managers.ImageManager;
using mms_api.Managers.PaymentManeger;
using mms_api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
var env = builder.Environment;

// ----- Database -----
builder.Services.AddCustomizedDatabase(configuration: config, env: env);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<Business>();
builder.Services.AddTransient<Payment>();
builder.Services.AddTransient<Image>();
builder.Services.AddTransient<BusinessManager>();
builder.Services.AddTransient<PaymentManager>();
builder.Services.AddTransient<BankManager>();
builder.Services.AddTransient<ImageManger>();

builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();


var app = builder.Build();
// Migrations
await using var scope = app.Services.CreateAsyncScope();


using var dbc = scope.ServiceProvider.GetService<DatabaseContext>();
await dbc.Database.MigrateAsync();

// migrate 
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();