using CoreProject.API.CQRS.Commands.AppUserCommand;
using CoreProject.API.CQRS.Commands.ExperienceCommand;
using CoreProject.API.CQRS.Queries.AnnouncementQuery;
using CoreProject.API.CQRS.Queries.AppUserQuery;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreProject.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("AppUserRegister")]
        public async Task<IActionResult> AppUserRegister(AppUserRegisterCommand appUserRegisterCommand )
        {
            var values = await _mediator.Send(appUserRegisterCommand);
            if (values == false)
            {
                return BadRequest("Kayıt Başarısız");
            }
            else
            {
                return Ok(values);                
            }
        }
        //[HttpPost]
        //[Route("AppUserLogin")]
        //public async Task<IActionResult> AppUserLogin(AppUserLoginQuery appUserLoginQuery)
        //{
        //    var values = await _mediator.Send(appUserLoginQuery);
        //    if (values != null)
        //    {
        //        return Ok(values);

        //    }
        //    else
        //    {
        //        return BadRequest("Kullanıcı adı veya şifre yanlış");
        //    }
        //}

        [HttpGet]
        [Route("GetUserCount")]
        public async Task<IActionResult> GetUserCount()
        {
            var values = await _mediator.Send(new GetUserTotalCountQuery());
            return Ok(values);
        }


    }
}
