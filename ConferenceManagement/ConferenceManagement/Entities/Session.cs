using System.Collections.Generic;

namespace ConferenceManagement.Entities
{
    public class Session    
    {
        public List<Talk> MorningSession { get; set; }
        public List<Talk> AfternoonSession { get; set; }
    }
}