using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SISTEMA_EVENTOS.MODEL.Models;
using SISTEMA_EVENTOS.Areas.Identity.Data;
using SISTEMA_EVENTOS.MODEL.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefautConnection") /*?? throw new InvalidOperationException("Connection string 'Identity_ContextConnection' not found.")*/;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GerenciamentoEventosContext>(options => options.UseSqlServer("Server=DESKTOP-UL25EN3\\SQLEXPRESS;Database=GerenciamentoEventos;Trusted_Connection=True;trustservercertificate=true"));
builder.Services.AddDbContext<Identity_Context>(options => options.UseSqlServer("Server=DESKTOP-UL25EN3\\SQLEXPRESS;Database=GerenciamentoEventos;Trusted_Connection=True;trustservercertificate=true"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Identity_Context>();
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
app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
