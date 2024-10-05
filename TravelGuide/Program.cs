using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TravelGuide.Context;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Implementation;
using TravelGuide.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(opt => 
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    //idk what it's doing but it fixed the error :)
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 3;
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUploadFile, UploadFile>();

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
