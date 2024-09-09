using FurnitureSellingCore.Context;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingInfra.Repos;
using FurnitureSellingInfra.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Configuration;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepos,UserRepos>();
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IItemRepos, ItemRepos>();
builder.Services.AddScoped<IItemServices, ItemServices>();
builder.Services.AddScoped<IItemRequestRepos, ItemRequestRepos>();
builder.Services.AddScoped<IItemRequestServices, ItemRequestServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderRepos, OrderRepos>();
builder.Services.AddScoped<IWishListServices, WishListServices>();
builder.Services.AddScoped<IWishListRepos, WishListRepos>();
builder.Services.AddScoped<ICartItemRepose, CartItemRepose>();
builder.Services.AddScoped<ICartItemServices, CartItemServices>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<ICartRepos, CartRepos>();
builder.Services.AddScoped<IProductWarrantyServies, ProductWarrantyServies>();
builder.Services.AddScoped<IProductWarrantyRepose, ProductWarrantyRepose>();
builder.Services.AddScoped<IRaviewRepose, RaviewRepose>();
builder.Services.AddScoped<IRaviewServices, RaviewServices>();
// to all acess to apo
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "default", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


//to docomention
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen();
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FurnitureSelling API",
        Version = "v1",
        Description = "An API to Selling",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Rania taweel",
            Email = "Raniataweelee@outlook.com",

        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(configuration.GetValue<string>("LoggerFilePath")
                , rollingInterval: RollingInterval.Day).MinimumLevel.Debug().
                CreateLogger();
Serilog.Log.Logger=new LoggerConfiguration().ReadFrom.Configuration(configuration).WriteTo.
    File(configuration.GetValue<string>("LoggerErrorFilePath"),
    rollingInterval: RollingInterval.Day).CreateLogger();
builder.Services.AddDbContext<FurnitureSellingDbContext>(x => x.UseMySQL(builder.Configuration.GetConnectionString("Mysqlconnect")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();// to serve files
//add custom staic files middlewre
var imgesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imgesDirectory),
    RequestPath = "/Images"

});

app.UseAuthorization();
app.UseCors("default");
app.MapControllers();
app.Run();