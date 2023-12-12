using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using CoreProject.DAL.Concrete;
using CoreProject.Entity.Concrete;
using CoreProject.UI.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Configuration;

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
//builder.Services.AddValidatorsFromAssemblyContaining<ExperienceVM>();

builder.Services.AddControllers()
                .AddFluentValidation(x =>
                {
                    x.ImplicitlyValidateChildProperties = true;
                    x.ImplicitlyValidateRootCollectionElements = true;
                    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    x.DisableDataAnnotationsValidation=true;
                });

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Writer/Login/Index/");
    options.AccessDeniedPath = new PathString("/ErrorPage/Index/");
    options.Cookie = new CookieBuilder
    {
        Name = "AspNetCoreIdentityExampleCookie", //Oluþturulacak Cookie'yi isimlendiriyoruz.
        HttpOnly = false, //Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
        MaxAge = TimeSpan.FromMinutes(2),
        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
        SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden eriþilebilir yapýyoruz.
    };
    //options.SlidingExpiration = true; //Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa eðer geri kalan yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
    options.ExpireTimeSpan = TimeSpan.FromMinutes(2); //CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan deðerlerle ezilme ihtimaline karþýn tekrardan Cookie vadesi burada da belirtiliyor.
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
app.UseNotyf();
