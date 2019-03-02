using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HealthChecker.Models
{
    public class ResponseModel
    {
        [JsonProperty("isHealthy")]
        public bool IsHealthy { get; set; }
    }
}
