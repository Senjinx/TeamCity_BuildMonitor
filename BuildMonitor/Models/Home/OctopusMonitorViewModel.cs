using System;
using System.Collections.Generic;

namespace BuildMonitor.Models.Home
{
    public class OctopusMonitorViewModel
    {
        public List<OctopusProject> OctopusProjects { get; set; }

        public OctopusMonitorViewModel(dynamic json)
        {
            OctopusProjects = new List<OctopusProject>();
            foreach (var project in json.Projects)
            {
                if (Object.ReferenceEquals(null, project))
                {
                    continue;
                }
                OctopusProjects.Add(new OctopusProject(json, project));
            }
        }
    }
}