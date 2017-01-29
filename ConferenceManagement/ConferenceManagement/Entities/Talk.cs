namespace ConferenceManagement.Entities
{
    public class Talk
    {
        public Talk(string topic, int duration)
        {
            Topic = topic;
            Duration = duration;
        }

        public string Topic { get; set; }
        public int Duration { get; set; }
    }
}