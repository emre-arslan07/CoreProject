using CoreProject.API.CQRS.Handlers.FeatureHandler;
using CoreProject.BLL.Abstract;
using CoreProject.BLL.Concrete;
using CoreProject.DAL.Abstract;
using CoreProject.DAL.Concrete;
using CoreProject.DAL.EntityFramework;
using CoreProject.DAL.UnitOfWork;
using CoreProject.Entity.Concrete;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using CoreProject.API.CQRS.Handlers.AboutHandler;
using CoreProject.API.CQRS.Handlers.ServiceHandler;
using CoreProject.API.CQRS.Handlers.ContactHandler;
using CoreProject.API.CQRS.Handlers.ExperienceHandle;
using CoreProject.API.CQRS.Handlers.PortfolioHandler;
using CoreProject.API.CQRS.Handlers.SkillHandler;
using CoreProject.API.CQRS.Handlers.SocialMediaHandler;
using CoreProject.API.CQRS.Handlers.TestimonialHandler;
using CoreProject.API.CQRS.Handlers.MessageHandler;
using CoreProject.API.CQRS.Handlers.AppUserHandler;
using CoreProject.API.CQRS.Handlers.AnnouncementHandler;
using CoreProject.API.CQRS.Handlers.WriterMessage;
using CoreProject.API.CQRS.Commands.WriterMessageCommand;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<CoreProjectDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CoreProjectDbContext>().AddEntityFrameworkStores<CoreProjectDbContext>();


builder.Services.AddScoped<IFeatureDal, EFFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IAboutDal,EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IServiceDal,EFServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IContactDal,EFContactDal>();
builder.Services.AddScoped<IContactService,ContactManager>();

builder.Services.AddScoped<IExperinceDal,EFExperinceDal>();
builder.Services.AddScoped<IExperienceService,ExperienceManager>();

builder.Services.AddScoped<IPortfolioDal,EFPortfolioDal>();
builder.Services.AddScoped<IPortfolioService,PortfolioManager>();

builder.Services.AddScoped<ISkillDal,EFSkillDal>();
builder.Services.AddScoped<ISkillService,SkillManager>();

builder.Services.AddScoped<IPortfolioDal, EFPortfolioDal>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();

builder.Services.AddScoped<ISocialMediaDal, EFSocialMedia>();
builder.Services.AddScoped<ISocialMediaService,SocialManager>();

builder.Services.AddScoped<ITestimonialDal,EFTestimonialDal>();
builder.Services.AddScoped<ITestimonialService,TestimonialManager>();

builder.Services.AddScoped<IMessageDal,EFMessageDal>();
builder.Services.AddScoped<IMessageService,MessageManager>();

builder.Services.AddScoped<IAppUserDal,EFAppUserDal>();
builder.Services.AddScoped<IAppUserService,AppUserManager>();

builder.Services.AddScoped<IAnnouncementDal,EFAnnouncementDal>();
builder.Services.AddScoped<IAnnouncementService,AnnouncementManager>();

builder.Services.AddScoped<IWriterMessageDal, EFWriterMessageDal>();
builder.Services.AddScoped<IWriterMessageService, WriterMessageManager>();



builder.Services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();

builder.Services.AddScoped<GetAllAboutQueryHandler>();
builder.Services.AddScoped<GetAllSocialMediaQueryHandler>();
builder.Services.AddScoped<SendMessageCommandHandler>();

builder.Services.AddScoped<GetAllSkillQueryHandler>();
builder.Services.AddScoped<DeleteSkillCommandHandler>();
builder.Services.AddScoped<AddSkillCommandHandler>();
builder.Services.AddScoped<UpdateSkillCommandHandler>();
builder.Services.AddScoped<GetSkillByIdCommandHandler>();
builder.Services.AddScoped<GetSkillTotalCountQueryHandler>();


builder.Services.AddScoped<GetAllExperienceQueryHandler>();
builder.Services.AddScoped<GetExperienceByIdCommandHandler>();
builder.Services.AddScoped<AddExperienceCommandHandler>();
builder.Services.AddScoped<DeleteExperienceCommandHandler>();
builder.Services.AddScoped<UpdateExperienceCommandHandler>();
builder.Services.AddScoped<GetExperienceTotalCountQueryHandler>();

builder.Services.AddScoped<GetAllPortfolioQueryHandler>();
builder.Services.AddScoped<GetPortfolioByIdQueryHandler>();
builder.Services.AddScoped<AddPortfolioCommandHandler>();
builder.Services.AddScoped<DeletePortfolioCommandHandler>();
builder.Services.AddScoped<UpdatePortfolioCommandHandler>();
builder.Services.AddScoped<GetLast5PortfolioQueryHandler>();
builder.Services.AddScoped<GetPortfolioTotalCountQueryHandler>();

builder.Services.AddScoped<GetAllFeatureQueryHandler>();
builder.Services.AddScoped<GetFeatureByIdQueryHandler>();
builder.Services.AddScoped<UpdateFeatureCommandHandler>();

builder.Services.AddScoped<GetAllServiceQueryHandler>();
builder.Services.AddScoped<AddServiceCommandHandler>();
builder.Services.AddScoped<DeleteServiceCommandHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();
builder.Services.AddScoped<GetServiceTotalCountQueryHandler>();

builder.Services.AddScoped<GetMessageTotalCountQueryHandler>();
builder.Services.AddScoped<GetTrueMessageTotalCountQueryHandler>();
builder.Services.AddScoped<GetFalseMessageTotalCountQueryHandler>();
builder.Services.AddScoped<GetAllMessageQueryHandler>();
builder.Services.AddScoped<GetMessageByIdQueryHandler>();
builder.Services.AddScoped<DeleteMessageCommandHandler>();

builder.Services.AddScoped<AppUserRegisterCommandHandler>();
builder.Services.AddScoped<AppUserLoginQueryHandler>();
builder.Services.AddScoped<GetUserTotalCountQueryHandler>();

builder.Services.AddScoped<GetAllAnnouncementQueryHandler>();
builder.Services.AddScoped<GetAnnouncementByIdQueryHandler>();
builder.Services.AddScoped<GetAnnouncementTotalCountQueryHandler>();
builder.Services.AddScoped<GetLast5AnnoucementQueryHandler>();

builder.Services.AddScoped<WriterMessageInboxQueryHandler>();
builder.Services.AddScoped<WriterMessageSendboxQueryHandler>();
builder.Services.AddScoped<GetWriterMessageByIdQueryHandler>();
builder.Services.AddScoped<SendWriterMessageCommandHandler>();
builder.Services.AddScoped<GetWriterMessageInboxCountQueryHandler>();

builder.Services.AddScoped<GetAllTestimonialQueryHandler>();
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();
builder.Services.AddScoped<AddTestimonialCommandHandler>();
builder.Services.AddScoped<DeleteTestimonialCommandHandler>();
builder.Services.AddScoped<UpdateTestimonialCommandHandler>();

builder.Services.AddScoped<GetAllContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

builder.Services.AddScoped<GetAllSocialMediaQueryHandler>();
builder.Services.AddScoped<GetSocialMediaByIdQueryHandler>();
builder.Services.AddScoped<AddSocialMediaCommandHandler>();
builder.Services.AddScoped<DeleteSocialMediaCommandHandler>();
builder.Services.AddScoped<UpdateSocialMediaCommandHandler>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CoreProjectApi", Version = "v1" });
  
});


builder.Services.AddCors(opt=>
{
    opt.AddPolicy("CoreProjectApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

   
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("CoreProjectApiCors");
app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");

app.Run();
