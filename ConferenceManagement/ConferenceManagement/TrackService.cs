using System.Collections.Generic;
using System.Linq;

namespace ConferenceManagement
{
    public class TrackService
    {
        public List<Track> CreateTracks(List<Talk> talks)
        {
            var tracks = new List<Track>();
            var track = CreateTrack(talks);
            tracks.Add(track);

            if (GetListOfTalksNotInPreviousTrack(talks, track).Any())
            {
                var talksNotInPrevioustrack = GetListOfTalksNotInPreviousTrack(talks, track);
                var newTrack = CreateTrack(talksNotInPrevioustrack);
                tracks.Add(newTrack);
            }

            return tracks;
        }

        private Track CreateTrack(List<Talk> talks)
        {
            var track = new Track();
            var factory = new SessionFactory();

            var sessions = factory.CreateSessions(talks);
            track.MorningSesion = sessions.MorningSession;
            track.AfternoonSession = sessions.AfternoonSession;
            return track;
        }

        private List<Talk> GetListOfTalksNotInPreviousTrack(List<Talk> talks, Track track)
        {
            var trackTalks = new List<Talk>();
            trackTalks.AddRange(track.MorningSesion);
            trackTalks.AddRange(track.AfternoonSession);


            var result = talks.Where(talk => trackTalks.All(m => m.Topic != talk.Topic)).ToList();
            return result;
        }

    }
}