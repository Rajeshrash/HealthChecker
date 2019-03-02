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
            List<ResponseModel> responseList = new List<ResponseModel>();
            try
            {
                bool response = HealthCheckerHelper.IsHealthy();
                if (response)
                    return new ResponseModel
                    {
                        IsHealthy = response,
                    };
            }
            catch(Exception e)
            {
                //Log Exception
            }
            return StatusCode(500);
        }

        [HttpGet("getValues")]
        public List<ResourceModel> GetValues()
        {
            return HealthCheckerHelper.getList();
        }
    }
}