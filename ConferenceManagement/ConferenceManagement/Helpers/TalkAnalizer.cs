using System;
using System.Text.RegularExpressions;

namespace ConferenceManagement.Helpers
{
    public static class TalkAnalizer
    {
        private const string Lightning = "lightning";

        public static int GetDuration(string topic, string line)
        {
            int duration;
            if (!topic.Contains(Lightning) && line.Contains(Lightning))
            {
                duration = 5;
            }
            else
            {
                duration = Convert.ToInt32(Regex.Split(line, @"\D+")[1]);
            }
            return duration;
        }

        public static string GetTopic(string line)
        {
            if (line.Contains(Lightning))
            {
                var topic = Regex.Split(line, "\\blightning\\b");
                return topic[0].Trim();

            }
            else
            {
                var topic = Regex.Match(line, @"([-a-zA-Z ]+)").Groups[0].ToString();
                return topic.Trim();
            }
        }
    }
}