using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildMonitor.Models.Home
{
    public class OctopusEnvironment
    {

        public String Name { get; set; }
        public String Id { get; set; }
        public OctopusItem OctopusItem { get; set; }

        public OctopusEnvironment(dynamic json, dynamic e, dynamic project)
        {
            List<dynamic> itemList = json.Items.ToObject<List<dynamic>>();

            Name = e.Name;
            Id = e.Id;
            OctopusItem = itemList
                .Select(i => new OctopusItem(i))
                .FirstOrDefault(i => i.ProjectId.Equals(project.Id.ToString())
                                      && i.EnvironmentId.Equals(e.Id.ToString()));
        }
    }
}