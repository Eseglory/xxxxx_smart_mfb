using Smart.MFB.ERP.Client.Core.Contract;
using Smart.MFB.ERP.Client.Core.Entities;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Presentation.WebClient.Core;
using Smart.MFB.ERP.Presentation.WebClient.Models;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Smart.MFB.ERP.Presentation.WebClient.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/country")]
    [UsesDisposableService]
    public class CountryApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public CountryApiController(ICoreService coreService)
        {
            _CoreService = coreService;
        }

        ICoreService _CoreService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_CoreService);
        }

        #region Country

        [HttpPost]
        [Route("updatecountry")]
        public HttpResponseMessage UpdateCountry(HttpRequestMessage request, [FromBody]Country countryModel)
        {
            return GetHttpResponse(request, () =>
            {
                var country = _CoreService.UpdateCountry(countryModel);

                return request.CreateResponse<Country>(HttpStatusCode.OK, country);
            });
        }

        [HttpPost]
        [Route("deletecountry")]
        public HttpResponseMessage DeleteCountry(HttpRequestMessage request, [FromBody]int countryId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                Country country = _CoreService.GetCountry(countryId);

                if (country != null)
                {
                    _CoreService.DeleteCountry(countryId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No country found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getcountry/{countryId}")]
        public HttpResponseMessage GetCountry(HttpRequestMessage request, long countryId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var countryModel = new CountryModel();

                Country country = _CoreService.GetCountry(countryId);
                StateData[] states = _CoreService.GetStates(country.Code);

                countryModel.Country = country;
                countryModel.States = states;

                // notice no need to create a seperate model object since Country entity will do just fine
                response = request.CreateResponse<CountryModel>(HttpStatusCode.OK, countryModel);

                return response;
            });
        }

        [HttpGet]
        [Route("availablecountries")]
        public HttpResponseMessage GetAvailableCountrys(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                Country[] countrys = _CoreService.GetAllCountries();

                return request.CreateResponse<Country[]>(HttpStatusCode.OK, countrys);
            });
        }

        #endregion

        #region State

        [HttpPost]
        [Route("updatestate")]
        public HttpResponseMessage UpdateState(HttpRequestMessage request, [FromBody]State stateModel)
        {
            return GetHttpResponse(request, () =>
            {
                var state = _CoreService.UpdateState(stateModel);

                return request.CreateResponse<State>(HttpStatusCode.OK, state);
            });
        }

        [HttpPost]
        [Route("deletestate")]
        public HttpResponseMessage DeleteState(HttpRequestMessage request, [FromBody]int stateId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                State state = _CoreService.GetState(stateId);

                if (state != null)
                {
                    _CoreService.DeleteState(stateId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No country role found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getstate/{stateId}")]
        public HttpResponseMessage GetState(HttpRequestMessage request, long stateId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var stateModel = new StateModel();

                State state = _CoreService.GetState(stateId);
                CityData[] cities = _CoreService.GetCities(stateId);

                stateModel.State = state;
                stateModel.Cities = cities;

                // notice no need to create a seperate model object since State entity will do just fine
                response = request.CreateResponse<StateModel>(HttpStatusCode.OK, stateModel);

                return response;
            });
        }


        [HttpGet]
        [Route("getcountrystate/{stateId}")]
        public HttpResponseMessage GetCountryState(HttpRequestMessage request, string countryCode)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                StateData[] state = _CoreService.GetStates(countryCode);

                // notice no need to create a seperate model object since State entity will do just fine
                response = request.CreateResponse<StateData[]>(HttpStatusCode.OK, state);

                return response;
            });
        }


        [HttpGet]
        [Route("getcountryshortcode/{countryCode}")]
        public HttpResponseMessage GetCountryShortCode(HttpRequestMessage request, string countryCode)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                string shortcode = _CoreService.GetCountryShortCode(countryCode);

                // notice no need to create a seperate model object since State entity will do just fine
                response = request.CreateResponse(HttpStatusCode.OK, shortcode);

                return response;
            });
        }
        #endregion


        [HttpGet]
        [Route("availablestates/{countryCode}")]
        public HttpResponseMessage GetAvailableStates(HttpRequestMessage request, string countryCode)
        {
            return GetHttpResponse(request, () =>
            {
                StateData[] states = _CoreService.GetStates(countryCode);

                return request.CreateResponse<StateData[]>(HttpStatusCode.OK, states);
            });
        }

        #region City

        [HttpPost]
        [Route("updatecity")]
        public HttpResponseMessage UpdateCity(HttpRequestMessage request, [FromBody]City cityModel)
        {
            return GetHttpResponse(request, () =>
            {
                var city = _CoreService.UpdateCity(cityModel);

                return request.CreateResponse<City>(HttpStatusCode.OK, city);
            });
        }

        [HttpPost]
        [Route("deletecity")]
        public HttpResponseMessage DeleteCity(HttpRequestMessage request, [FromBody]int cityId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // not that calling the WCF service here will authenticate access to the data
                City city = _CoreService.GetCity(cityId);

                if (city != null)
                {
                    _CoreService.DeleteCity(cityId);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "No country role found under that ID.");

                return response;
            });
        }

        [HttpGet]
        [Route("getcity/{cityId}")]
        public HttpResponseMessage GetCity(HttpRequestMessage request, long cityId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var city = _CoreService.GetCity(cityId);

                // notice no need to create a seperate model object since City entity will do just fine
                response = request.CreateResponse<City>(HttpStatusCode.OK, city);

                return response;
            });
        }

        [HttpGet]
        [Route("availablecities/{stateId}")]
        public HttpResponseMessage GetAvailableCities(HttpRequestMessage request, long stateId)
        {
            return GetHttpResponse(request, () =>
            {
                CityData[] cities = _CoreService.GetCities(stateId);

                return request.CreateResponse<CityData[]>(HttpStatusCode.OK, cities);
            });
        }

        #endregion
    }
}
