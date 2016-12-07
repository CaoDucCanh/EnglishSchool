using AutoMapper;
using EnglishSchool.Web.Infrastructure.Core;
using EnglishSchool.Web.Infrastructure.Extensions;
using EngLishSchool.Model.Models;
using EngLishSchool.Web.App_Start;
using EngLishSchool.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EnglishSchool.Web.Infrastructure.Core;
using EnglishSchool.Service;
using EnglishSchool.Common.Exceptions;
using EngLishSchool.Service;

namespace EnglishSchool.Web.Api
{

    [Authorize]
    [RoutePrefix("api/applicationUser")]
    public class ApplicationUserController : ApiControllerBase
    {
        private ApplicationUserManager _userManager;
        private ITypeUserService _typeUserService;
        private IApplicationRoleService _appRoleService;
        public ApplicationUserController(
            ITypeUserService typeUserService,
            IApplicationRoleService appRoleService,
            ApplicationUserManager userManager,
            IErrorService errorService)
            : base(errorService)

        {
            _appRoleService = appRoleService;
            _typeUserService = typeUserService;
            _userManager = userManager;
        }

        [Route("getlistpaging")]
        [HttpGet]
        [Authorize(Roles = "ViewUser")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = _userManager.Users;
                IEnumerable<ApplicationUserViewModel> modelVm = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(model);

                PaginationSet<ApplicationUserViewModel> pagedSet = new PaginationSet<ApplicationUserViewModel>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "AddUser")]
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
