using System;
using System.Collections.Generic;
using System.Linq;
using BuildMonitor.Helpers;

namespace BuildMonitor.Models.Home
{
    public class OctopusEnvironment
    {

        public String Name { get; set; }
        public String Id { get; set; }
        public List<OctopusItem> OctopusItems { get; set; }
        public OctopusItem OctopusItem { get; set; }
        public ItemState State { get; set; }


        public OctopusEnvironment(dynamic json, dynamic e)
        {
            OctopusItems = new List<OctopusItem>();
            Name = e.Name;
            Id = e.Id;

            List<dynamic> itemList = json.Items.ToObject<List<dynamic>>();
            
            foreach (var item in itemList)
            {
                if (Id.Equals(item.EnvironmentId.ToString()))
                {
                    OctopusItems.Add(new OctopusItem(item));
                }
            }
        }
    }
}