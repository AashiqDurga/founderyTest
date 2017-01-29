using System;
using System.IO;
using ConferenceManagement.Helpers;
using ConferenceManagement.Services;

namespace ConferenceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "input.txt");
            var parser = new TalkParser();
            var talks = parser.Parse(filePath);

            var trackService = new TrackService();
            var tracks = trackService.CreateTracks(talks);

            var trackNumber = 1;
            foreach (var track in tracks)
            {
                var morningStartTime = new TimeSpan(09, 00, 0);
                var afternoonStartTime = new TimeSpan(01, 00, 0);

                Console.WriteLine("Track: " + trackNumber++);
                Console.WriteLine("");

                foreach (var talk in track.MorningSesion)
                {
                    Console.WriteLine(morningStartTime.ToString(@"hh\:mm") + " AM" + " " + talk.Topic + " " + (talk.Duration == 5 ? "lightning" : talk.Duration + " Min"));
                    morningStartTime = morningStartTime.Add(new TimeSpan(00, talk.Duration, 00));
                }

                Console.WriteLine("12:00 PM Lunch");
                foreach (var talk in track.AfternoonSession)
                {
                    Console.WriteLine(afternoonStartTime.ToString(@"hh\:mm") + " PM" + " " + talk.Topic + " " + (talk.Duration == 5 ? "lightning" : talk.Duration + " Min"));
                    afternoonStartTime = afternoonStartTime.Add(new TimeSpan(00, talk.Duration, 00));
                }
                Console.WriteLine("05:00 PM Networking Event");
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
