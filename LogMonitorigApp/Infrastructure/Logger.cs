using LogMonitorigApp.Models;

namespace LogMonitorigApp.Infrastructure
{
    public static class Logger
    {
        public static void Run(string path)
        {
            List<JobEvent> jobEvents = new List<JobEvent>();
            List<JobLog> jobLogs = new List<JobLog>();

            Console.WriteLine("Read log file...");
            try
            {
                jobEvents = LogReader.ReadJobs(path);
            }
            catch
            {
                Console.WriteLine("Could not read the log file.");
                throw;
            }
            Console.WriteLine("Finished reading the log file.");

            Console.WriteLine("Processing logs...");
            try
            {
                jobLogs = JobProcessor.GetJobLogs(jobEvents);
            }
            catch
            {
                Console.WriteLine("Could not process logs.");
                throw;
            }
            Console.WriteLine("Finished processing logs.");

            Console.WriteLine("Write log result file.");
            try
            {
                LogWriter.WriteJobs(jobLogs, path);
            }
            catch
            {
                Console.WriteLine("Could not write log result file.");
                throw;
            }
        }
    }
}
