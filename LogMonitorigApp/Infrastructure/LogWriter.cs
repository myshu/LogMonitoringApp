using System.Globalization;
using CsvHelper;
using LogMonitorigApp.Models;

namespace LogMonitorigApp.Infrastructure
{
    public static class LogWriter
    {
        public static void WriteJobs(List<JobLog> jobs, string path)
        {
            using (var writer = new StreamWriter(string.Format("{0}LogResponses.log", path)))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(jobs);
            }
        }
    }
}
