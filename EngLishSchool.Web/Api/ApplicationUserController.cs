using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EnglishSchool.Common.Exceptions;
using EnglishSchool.Service;
using EnglishSchool.Web.Infrastructure.Core;
using EnglishSchool.Web.Infrastructure.Extensions;
using EngLishSchool.Model.Models;
using EngLishSchool.Service;
using EngLishSchool.Web.App_Start;
using EngLishSchool.Web.Models;
using Microsoft.AspNet.Identity;

namespace EngLishSchool.Web.Api
{
    [RoutePrefix("api/applicationuser")]
    public class ApplicationUserController : ApiControllerBase
    {
        private ApplicationUserManager _userManager;
        private IApplicationUserService _appUserService;
        private IApplicationRoleService _appRoleService;
        public ApplicationUserController(
            IApplicationUserService appUserService,
            IApplicationRoleService appRoleService,
            ApplicationUserManager userManager,
            IErrorService errorService)
            : base(errorService)
        {
            _appRoleService = appRoleService;
            _appUserService = appUserService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Create(HttpRequestMessage request, ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppUser = new ApplicationUser();
                newAppUser.UpdateUser(applicationUserViewModel);
                try
                {
                    newAppUser.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
                    if (result.Succeeded)
                    {
                        //add role to user
                        var listRole = _appRoleService.GetAllrole();
                        foreach (var role in listRole)
                        {
                            await _userManager.RemoveFromRoleAsync(newAppUser.Id, role.Name);
                            await _userManager.AddToRoleAsync(newAppUser.Id, role.Name);
                        }

                        return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);

                    }
                    else
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
                catch (Exception ex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
