using System.Collections.Generic;
using System.Linq;
using ConferenceManagement.Entities;

namespace ConferenceManagement.Factories
{
    public class SessionFactory
    {
        public Session CreateSessions(List<Talk> talks)
        {
            var sessions = new Session();

            var morningSession = CreateMorningSession(talks);
            var talksnotNotInMorningSession = GetListOfTalksNotInMorning(talks, morningSession);

            var afternoonSession = CreateAfternoonSession(talksnotNotInMorningSession);
            sessions.MorningSession = morningSession;
            sessions.AfternoonSession = afternoonSession;

            return sessions;
        }

        public List<Talk> CreateMorningSession(List<Talk> listOfTalks)
        {
            var session = new List<Talk>();

            foreach (var talk in listOfTalks)
            {
                if (session.Sum(x => x.Duration) != 180 && CurrentDurationofsessionPlusTalk(session,talk) < 180)
                {
                    session.Add(talk);
                }
            }
            return session;
        }

        public List<Talk> CreateAfternoonSession(List<Talk> listOfTalksExcludingMorningTalks)
        {
            var session = new List<Talk>();

            foreach (var talk in listOfTalksExcludingMorningTalks)
            {
                if (session.Sum(x => x.Duration) < 240 && CurrentDurationofsessionPlusTalk(session, talk) < 240)
                {
                    session.Add(talk);
                }
            }

            return session;
        }

        private static int CurrentDurationofsessionPlusTalk(ICollection<Talk> session, Talk talk)
        {
            session.Add(talk);
            var durationcount = session.Sum(x => x.Duration);
            session.Remove(talk);

            return durationcount;
        }

        private static List<Talk> GetListOfTalksNotInMorning(IEnumerable<Talk> talks, List<Talk> morningSession)
        {
            var result = talks.Where(talk => morningSession.All(m => m.Topic != talk.Topic)).ToList();
            return result;
        }
    }
}