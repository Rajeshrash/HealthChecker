using HealthChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChecker
{
    public static class Constants
    {
        public static List<ResourceModel> ResourceList { get; set; } = new List<ResourceModel>()
        {
            new ResourceModel{ IsHealthy=true,ResouceName="R1"  },
            new ResourceModel{ IsHealthy=true,ResouceName="R2"  },
            new ResourceModel{ IsHealthy=true,ResouceName="R3"  },
        };
    }
}
