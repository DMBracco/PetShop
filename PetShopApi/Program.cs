using BLL.Entities;
using BLL.IRepositories;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShopApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration["ConnectionStrings:Connection"];
builder.Services.AddDbContext<ShopContext>(opts => {
    opts.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ShopContext>();

builder.Services.AddScoped<IGenericRepository<Manufacturer>, GenericRepository<Manufacturer>>();
builder.Services.AddScoped<IGenericRepository<Supply>, GenericRepository<Supply>>();
builder.Services.AddScoped<IGenericRepository<Check>, GenericRepository<Check>>();
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IGenericRepository<BonusCard>, GenericRepository<BonusCard>>();
builder.Services.AddScoped<IGenericRepository<ProductType>, GenericRepository<ProductType>>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
