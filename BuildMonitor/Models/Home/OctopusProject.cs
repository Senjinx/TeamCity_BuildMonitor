using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildMonitor.Models.Home
{
    public class OctopusProject
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public List<OctopusEnvironment> OctopusEnvironments { get; set; }
        public OctopusProject(dynamic json, dynamic project)
        {
            List<dynamic> environmentList = json.Environments.ToObject<List<dynamic>>();
            List<dynamic> currentEnvironmentList = project.EnvironmentIds.ToObject<List<dynamic>>();

            OctopusEnvironments = new List<OctopusEnvironment>();
            Id = project.Id;
            Name = project.Name;
            OctopusEnvironments.AddRange(environmentList
                .Where(e => currentEnvironmentList.Contains(e.Id.ToString()))
                .Select(e => new OctopusEnvironment(json, e, project)));
        }
    }
}