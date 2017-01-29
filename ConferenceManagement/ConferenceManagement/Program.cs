using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new TalkParser();
            var talks = parser.Parse(@"C:\src\FounderyTest\founderyTest\ConferenceManagement\ConferenceManagement\input.txt");

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
                    
                    Console.WriteLine(morningStartTime.ToString(@"hh\:mm")+ " AM" + " " + talk.Topic + " " + talk.Duration + " Min");
                    morningStartTime = morningStartTime.Add(new TimeSpan(00, talk.Duration, 00));
                }

                Console.WriteLine("12:00 PM Lunch");
                foreach (var talk in track.AfternoonSession)
                {
                    Console.WriteLine(afternoonStartTime.ToString(@"hh\:mm")+ " PM" + " " + talk.Topic + " " + talk.Duration + " Min");
                    afternoonStartTime = afternoonStartTime.Add(new TimeSpan(00, talk.Duration, 00));

                }
                Console.WriteLine("05:00 PM Networking Event");
                Console.WriteLine("");
                Console.WriteLine("");

            }

            Console.ReadLine();
        }
    }
}
