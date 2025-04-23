using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using LogMonitorigApp.Infrastructure.Mapping;
using LogMonitorigApp.Models;

namespace LogMonitorigApp.Infrastructure
{
    public static class LogReader
    {
        public static List<JobEvent> ReadJobs(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                TrimOptions = TrimOptions.Trim
            };

            using (var reader = new StreamReader(string.Format("{0}logs.log", path)))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<JobEventMap>();
                return csv.GetRecords<JobEvent>().ToList();
            }
        }
    }
}
