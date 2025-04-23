using LogMonitorigApp.Models;

namespace LogMonitorigApp.Infrastructure
{
    public static class JobProcessor
    {
        public static List<JobLog> GetJobLogs(List<JobEvent> jobEvents)
        {
            var jobLogs = new List<JobLog>();

            // separate jobs by START / END 
            var endJobEvents = jobEvents.Where(j => j.State == State.END).ToList();
            var startJobEvents = jobEvents.Where(j => j.State == State.START).ToList();

            foreach (var endJobEvent in endJobEvents)
            {
                // find the coresponding start of an end event
                var startJobEvent = startJobEvents.First(j => j.PID == endJobEvent.PID);

                // calculate how long the job was running
                var jobDuration = endJobEvent.DateTime.Subtract(startJobEvent.DateTime);

                // add error log if job took longer thatn 10 minutes
                if (jobDuration > TimeSpan.FromMinutes(10))
                {
                    jobLogs.Add(new JobLog
                    {
                        PID = endJobEvent.PID,
                        Description = endJobEvent.Description,
                        LogSeverity = LogSeverity.Error
                    });
                }

                // if is not longer than 10 minutes but longer than 5 then add warning log
                else if (jobDuration > TimeSpan.FromMinutes(5))
                {
                    jobLogs.Add(new JobLog
                    {
                        PID = endJobEvent.PID,
                        Description = endJobEvent.Description,
                        LogSeverity = LogSeverity.Warning
                    });
                }
            }

            return jobLogs;
        }
    }
}
