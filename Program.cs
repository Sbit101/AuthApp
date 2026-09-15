using AuthApp.Data;
using AuthApp.Hubs;
using AuthApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System.Configuration;

//using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);


//cors
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddCors(options => {
//options.AddPolicy(name: MyAllowSpecificOrigins, policy => {
//    policy.WithOrigins(SameSiteMode.Strict.ToString()); //"http://example.com","http://www.contoso.com" 
//});


//builder.Services.AddSignalR();



//var cookie = "_cookie";
builder.Services.AddCookiePolicy(options => {

    options.HttpOnly.Equals(false);
    //options.Secure.Equals(true);
    options.Secure.Equals(CookieSecurePolicy.Always.ToString());
});





/// Add services to the container.---OLD sqlserver
///var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
///builder.Services.AddDbContext<ApplicationDbContext>(options =>
///    options.UseSqlServer(connectionString));
///builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Add services to the container. New SQLITE
var connectionString = builder.Configuration.GetConnectionString("litedb");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


///default changed 
///builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
///    .AddEntityFrameworkStores<ApplicationDbContext>();
///builder.Services.AddControllersWithViews();



///updated 
///builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultUI()
        .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//signalr new ---------------
builder.Services.AddSignalR();


var app = builder.Build();

//Csp response header (New)
//app.Use(async (ctx, next) => {

// ctx.Response.Headers.Add("Content-Security-Policy", "script-src self https://localhost:7232/js/ https://localhost:7232/lib/bootstrap/dist/js/bootstrap.bundle.min.js https://localhost:7232/lib/jquery/dist/jquery.min.js https://cdn.maptiler.com/; report-uri /cspreport");

///https://cdn.maptiler.com/maptiler-sdk-js/latest/maptiler-sdk.umd.min.js
///"Content-Security-Policy","script-src self https://cdn.maptiler.com/ usafe-inline; script-src-elem https//:localhost:7232/js/; report-uri /cspreport"
///"Content-Security-Policy", "script-src 'None' ~/wwwroot/* https://cdn.maptiler.com/ usafe-inline; report-uri /cspreport"
///"script-src 'self  form-action 'self';

///    "Content-Security-Policy", "default-src 'self'; img-src 'self'; report-uri /cspreport"

//await next();
//});





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//cors added here
//app.UseCors(MyAllowSpecificOrigins); 
app.UseCors(SameSiteMode.Strict.ToString());
//app.UseCookiePolicy(CookieSecurePolicy.Always.ToString());


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

//signalr new---------------------------
app.UseEndpoints(endpoints =>
{
    ///endpoints.MapRazorPages();
    ///endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chatHub");
});
//---------------------------------------


app.Run();
