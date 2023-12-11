using CoreProject.DAL.Concrete;
using CoreProject.Entity.Concrete;
using CoreProject.UI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddDbContext<CoreProjectDbContext>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<CoreProjectDbContext>();
builder.Services.AddHttpClient();

//builder.Services.AddControllersWithViews(opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
//});

//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//                .RequireAuthenticatedUser()
//                .Build();
//    config.Filters.Add(new AuthorizeFilter(policy));

//});

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
//    options.AccessDeniedPath = "/ErrorPage/Index/";
//    options.LoginPath = "/Writer/Login/Index/";
//});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Writer/Login/Index/");
    options.AccessDeniedPath = new PathString("/ErrorPage/Index/");
    options.Cookie = new CookieBuilder
    {
        Name = "AspNetCoreIdentityExampleCookie", //Olu�turulacak Cookie'yi isimlendiriyoruz.
        HttpOnly = false, //K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.
        MaxAge = TimeSpan.FromMinutes(2),
        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin g�nderilmemesini belirtiyoruz.
        SecurePolicy = CookieSecurePolicy.Always //HTTPS �zerinden eri�ilebilir yap�yoruz.
    };
    //options.SlidingExpiration = true; //Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa e�er geri kalan yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
    options.ExpireTimeSpan = TimeSpan.FromMinutes(2); //CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
    options.SlidingExpiration = true;

});
builder.Services.AddMvc();
var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
    app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");


app.Run();
