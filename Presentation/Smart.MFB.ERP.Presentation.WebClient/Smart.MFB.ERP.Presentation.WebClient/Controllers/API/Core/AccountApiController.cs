using Smart.MFB.ERP.Client.Core.Contract;
using entities = Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Smart.MFB.ERP.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/account")]
    [UsesDisposableService]
    public class AccountApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public AccountApiController(ISecurityAdapter securityAdapter, ICoreService coreService)
        {
            _SecurityAdapter = securityAdapter;
            _CoreService = coreService;
        }

        ISecurityAdapter _SecurityAdapter;
        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        [HttpGet]
        [Route("getprofile")]
        public HttpResponseMessage GetProfile(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                UserData account = _CoreService.GetUserProfile(User.Identity.Name);

                // notice no need to create a seperate model object since User entity will do just fine
                response = request.CreateResponse(HttpStatusCode.OK, account);

                return response;
            });
        }


    }
}
