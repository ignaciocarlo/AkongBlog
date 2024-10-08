using Microsoft.EntityFrameworkCore;
using AkongBlogInfrastructure.DependencyInjection;
using AkongBlogWeb.Areas.Identity.Data;
using AkongBlogWeb;
using Application;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructure(connectionString);
builder.Services.ConfigureDefaultServices();
builder.Services.AddApplicationServices();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
var scope = app.Services.CreateScope();
await DefaultRole.SeedData(scope.ServiceProvider);
await DefaultUser.SeedData(scope.ServiceProvider);

app.Run();


