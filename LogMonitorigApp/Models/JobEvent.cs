namespace LogMonitorigApp.Models
{
    public class JobEvent : Job
    {
        public DateTime DateTime { get; set; }
        public State State { get; set; }
    }
}
