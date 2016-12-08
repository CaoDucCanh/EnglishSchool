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

    [RoutePrefix("api/applicationUser")]

    public class ApplicationUserController : ApiControllerBase
    {
        private ApplicationUserManager _userManager;
        private IApplicationRoleService _appRoleService;
        private IApplicationUserService _appUserService;
        private ITypeUserService _typyUserService;
        public ApplicationUserController(
          IApplicationRoleService appRoleService, IApplicationUserService appUserService, ITypeUserService typyUserService,
            ApplicationUserManager userManager, IErrorService errorService)
            : base(errorService)
        {
            _typyUserService = typyUserService;
            _appUserService = appUserService;
            _appRoleService = appRoleService;
            _userManager = userManager;
        }
        [Route("getlistpaging")]
        [HttpGet]
     
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
       

        [Route("detail/{id}")]
        [HttpGet]
     
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {

                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var user = _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var applicationUserViewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user.Result);
     return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
            }
        
        }

        [HttpPost]
        [Route("add")]
    
        public async Task<HttpResponseMessage> Create(HttpRequestMessage request, ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppUser = new ApplicationUser();
                //   newAppUser.Email = "asffas@gmail.com";
                //   newAppUser.UserName = "fdsfsd";
                newAppUser.UpdateUser(applicationUserViewModel);
                var result = await _userManager.CreateAsync(newAppUser, "1fdsfsdT@");

                await _userManager.RemoveFromRoleAsync(newAppUser.Id, "Admin");
                await _userManager.AddToRoleAsync(newAppUser.Id, "Admin");

               
                try
                {
                    newAppUser.Id = Guid.NewGuid().ToString();
                   
                    if (result.Succeeded)
                    {
                        

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

     

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "DeleteUser")]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(appUser);
            if (result.Succeeded)
                return request.CreateResponse(HttpStatusCode.OK, id);
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
        }

    }
}
