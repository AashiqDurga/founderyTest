using System.Collections.Generic;

namespace ConferenceManagement
{
    public class Track
    {
        public List<Talk> MorningSesion { get; set; }
        public List<Talk> AfternoonSession { get; set; }
    }
}