using System.Collections.Generic;
using System.IO;
using ConferenceManagement.Entities;

namespace ConferenceManagement.Helpers
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
}