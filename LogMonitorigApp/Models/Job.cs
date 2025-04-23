namespace LogMonitorigApp.Models
{
    public abstract class Job
    {
        public string? Description { get; set; }
        public long PID { get; set; }
    }
}
