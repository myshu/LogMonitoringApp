using CsvHelper.Configuration;
using LogMonitorigApp.Models;

namespace LogMonitorigApp.Infrastructure.Mapping
{
    public class JobEventMap: ClassMap<JobEvent>
    {
        public JobEventMap()
        {
            Map(j => j.DateTime).Index(0);
            Map(j => j.Description).Index(1);
            Map(j => j.State).Index(2);
            Map(j => j.PID).Index(3);
        }
    }
}
