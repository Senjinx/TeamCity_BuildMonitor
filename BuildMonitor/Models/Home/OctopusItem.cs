using System;

namespace BuildMonitor.Models.Home
{
    public class OctopusItem
    {
        public String Id { get; set; }
        public String ProjectId { get; set; }
        public String EnvironmentId { get; set; }
        public String State { get; set; }
        public String ReleaseVersion { get; set; }

        public OctopusItem(dynamic i)
        {
            EnvironmentId = i.EnvironmentId;
            Id = i.Id;
            ProjectId = i.ProjectId;
            State = i.State;
            ReleaseVersion = i.ReleaseVersion;
        }


    }
}