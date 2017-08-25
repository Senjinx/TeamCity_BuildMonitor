using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Management;
using BuildMonitor.Helpers;

namespace BuildMonitor.Models.Home
{
    public class OctopusMonitorViewModel
    {
        public List<OctopusEnvironment> OctopusEnvironments { get; set; }

        public OctopusMonitorViewModel(dynamic json)
        {
            OctopusEnvironments = new List<OctopusEnvironment>();
            foreach (var environment in json.Environments)
            {
                if (Object.ReferenceEquals(null, environment))
                {
                    continue;
                }
                var tmp = new OctopusEnvironment(json, environment);
                if (tmp.OctopusItems.Count > 0)
                {
                    OctopusEnvironments.Add(tmp);
                }
            }
            foreach (var env in OctopusEnvironments)
            {
                var failed = env.OctopusItems.Any(i => !i.State.ToLower().Equals("success") && !i.State.ToLower().Equals("running"));
                var running = env.OctopusItems.Any(i => i.State.ToLower().Equals("running"));

                if (failed) { env.State = ItemState.Failed; }
                else if (running) { env.State = ItemState.Running; }
                else { env.State = ItemState.Success; }
            }
            
        }
    }
}