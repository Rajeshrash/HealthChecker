using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthChecker.Helpers;
using HealthChecker.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthChecker.Controllers
{
    [Produces("application/json")]
    [Route("api/HealthChecker")]
    public class HealthCheckerController : Controller
    {
        [HttpGet("isHealthy")]
        public Object IsHealthy()
        {
            try
            {
                if (HealthCheckerHelper.IsHealthy())
                    return new ResponseModel
                    {
                        IsHealthy = true,
                    };
            }
            catch(Exception e)
            {
                //Log Exception
            }
            return new { ResponseCode = StatusCode(500), FailedResources = Constants.ResourceList.FindAll(x => x.IsHealthy == false) };
        }

        [HttpGet("getValues")]
        public List<ResourceModel> GetValues()
        {
            return HealthCheckerHelper.getList();
        }
    }
}