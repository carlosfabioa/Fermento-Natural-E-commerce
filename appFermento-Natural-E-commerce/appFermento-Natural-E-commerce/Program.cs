using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using appFermento_Natural_E_commerce.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<appFermento_Natural_E_commerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("appFermento_Natural_E_commerceContext") ?? throw new InvalidOperationException("Connection string 'appFermento_Natural_E_commerceContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
