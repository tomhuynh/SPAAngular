using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Business.Facade.Demo;
using Contract.Facades;
using Contract.Models;

namespace WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IAlertFacade _demoFacade;

        public HomeController()
        {
            _demoFacade = new AlertFacade();
        }


        [HttpGet, Route("alerts")]
        public Task<List<Alert>> GetAlertsAsync()
        {
            try
            {
                return _demoFacade.GetAlertsAsync();

            }
            catch (Exception e)
            {
                var err = e.Message;
            }

            return null;
        }

    }
}
