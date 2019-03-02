using HealthChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChecker.Helpers
{
    public static class HealthCheckerHelper
    {
        static HealthCheckerHelper()
        {
            PollResources();
        }
        public static bool IsHealthy()
        {
            bool IsUnHealthy = false;
            try
            {
                Constants.ResourceList.ForEach(x=> {
                    if (x.IsHealthy == false)
                        IsUnHealthy = true;
                });
                return IsUnHealthy == true ? false : true;
            }
            catch(Exception e)
            {
                //Log Exception
            }
            return false;
        }

        public static void PollResources()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(10);
            var timer = new System.Threading.Timer((e) =>
            {
                Parallel.Invoke(() =>
                {
                    SetResource("R1", HealthStatus());
                },
                () => {
                    SetResource("R2", HealthStatus());
                },
                () => {
                    SetResource("R3", HealthStatus());
                });
            }, null, startTimeSpan, periodTimeSpan);
        }

        public static List<ResourceModel> getList()
        {
            return Constants.ResourceList;
        }

        public static bool HealthStatus()
        {
            Random rnd = new Random();
            int rndNumber = rnd.Next(1, 11);
            if (rndNumber > 7)
                return false;
            return true;
        }

        public static void SetResource(string resourceName,bool healthState)
        {
            Constants.ResourceList.ForEach(x =>
            {
                if (x.ResouceName.Equals(resourceName.ToUpper()))
                    x.IsHealthy = healthState;
            });
        }
    }
}
