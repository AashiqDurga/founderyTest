namespace ConferenceManagement
{
    public class Talk
    {
        public Talk(string topic, double duration)
        {
            Topic = topic;
            Duration = duration;
        }

        public string Topic { get; set; }
        public double Duration { get; set; }
    }
}