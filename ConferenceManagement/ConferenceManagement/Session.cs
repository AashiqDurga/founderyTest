using System.Collections.Generic;

namespace ConferenceManagement
{
    public class Session    
    {
        public List<Talk> MorningSession { get; set; }
        public List<Talk> AfternoonSession { get; set; }
    }
}