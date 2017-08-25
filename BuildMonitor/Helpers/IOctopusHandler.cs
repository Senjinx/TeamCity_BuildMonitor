using BuildMonitor.Models.Home;

namespace BuildMonitor.Helpers
{
    public interface IOctopusHandler
    {
        OctopusMonitorViewModel GetModel();
    }
}