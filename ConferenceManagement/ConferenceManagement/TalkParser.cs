using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ConferenceManagement
{
    public class TalkParser
    {
        public List<Talk> Parse(string inputTxtFilePath)
        {
            string line;
            var talks = new List<Talk>();

            StreamReader file = new StreamReader(inputTxtFilePath);

            while ((line = file.ReadLine()) != null)
            {
                var topic = TalkAnalizer.GetTopic(line);
                var duration = TalkAnalizer.GetDuration(topic, line);

                talks.Add(new Talk(topic, duration));
            }

            file.Close();
            return talks;
        }

    }

    public static class TalkAnalizer
    {
        public static int GetDuration(string topic, string line)
        {
            int duration;
            if (!topic.Contains("lightning") && line.Contains("lightning"))
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
            if (line.Contains("lightning"))
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