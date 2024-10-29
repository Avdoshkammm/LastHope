using LastHope.Application.DTO;
using LastHope.Application.Mapping;
using LastHope.Application.Service;
using LastHope.Domain.Entities;
using LastHope.Domain.Interfaces;
using LastHope.Infrastructure.Data;
using LastHope.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<GenericInterface<Product>, ProductRepository>();
builder.Services.AddScoped<GenericInterface<ProductDTO>, ProductService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<LastHopeDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
