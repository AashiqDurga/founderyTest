using System.Collections.Generic;
using System.Linq;

namespace ConferenceManagement
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
                if (session.Sum(x => x.Duration) != 180 && currentDurationofsessionPlusTalk(session,talk) < 180)
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
                if (session.Sum(x => x.Duration) < 240 && currentDurationofsessionPlusTalk(session, talk) < 240)
                {
                    session.Add(talk);
                }
            }

            return session;
        }

        private int currentDurationofsessionPlusTalk(List<Talk> session, Talk talk)
        {
            session.Add(talk);
            var durationcount = session.Sum(x => x.Duration);
            session.Remove(talk);

            return durationcount;
        }

        private List<Talk> GetListOfTalksNotInMorning(List<Talk> talks, List<Talk> morningSession)
        {
            var result = talks.Where(talk => morningSession.All(m => m.Topic != talk.Topic)).ToList();
            return result;
        }
    }
}