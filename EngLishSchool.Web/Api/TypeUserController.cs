using AutoMapper;
using EnglishSchool.Web.Infrastructure.Core;
using EngLishSchool.Model.Models;
using EngLishSchool.Service;
using EngLishSchool.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngLishSchool.Web.Api
{

    [RoutePrefix("api/Typeuser")]
    public class TypeUserController : ApiControllerBase
    {
        private ITypeUserService _typyUserService;
        public TypeUserController(
            ITypeUserService typyUserService,
              IErrorService errorService)
            : base(errorService)
        {
            _typyUserService = typyUserService;
           
        }
        [Route("getalltype")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _typyUserService.GetAll();

                var responseData = Mapper.Map<IEnumerable<TypeUser>, IEnumerable<TyperUserViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
