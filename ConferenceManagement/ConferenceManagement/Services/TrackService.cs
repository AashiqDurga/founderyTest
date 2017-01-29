using System.Collections.Generic;
using System.Linq;
using ConferenceManagement.Entities;
using ConferenceManagement.Factories;

namespace ConferenceManagement.Services
{
    public class TrackService
    {
        public List<Track> CreateTracks(List<Talk> talks)
        {
            var tracks = new List<Track>();
            var track = CreateTrack(talks);
            tracks.Add(track);

            if (!GetListOfTalksNotInPreviousTrack(talks, track).Any()) return tracks;
            var talksNotInPrevioustrack = GetListOfTalksNotInPreviousTrack(talks, track);
            var newTrack = CreateTrack(talksNotInPrevioustrack);
            tracks.Add(newTrack);

            return tracks;
        }

        private static Track CreateTrack(List<Talk> talks)
        {
            var track = new Track();
            var factory = new SessionFactory();

            var sessions = factory.CreateSessions(talks);
            track.MorningSesion = sessions.MorningSession;
            track.AfternoonSession = sessions.AfternoonSession;
            return track;
        }

        private static List<Talk> GetListOfTalksNotInPreviousTrack(IEnumerable<Talk> talks, Track track)
        {
            var trackTalks = new List<Talk>();
            trackTalks.AddRange(track.MorningSesion);
            trackTalks.AddRange(track.AfternoonSession);

            var result = talks.Where(talk => trackTalks.All(m => m.Topic != talk.Topic)).ToList();
            return result;
        }

    }
}