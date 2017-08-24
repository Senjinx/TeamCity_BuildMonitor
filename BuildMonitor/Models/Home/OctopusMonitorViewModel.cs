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
                OctopusProjects.Add(new OctopusProject(json, project));
            }
        }
    }
}