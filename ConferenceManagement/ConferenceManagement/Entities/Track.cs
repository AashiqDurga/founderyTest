using System.Collections.Generic;

namespace ConferenceManagement.Entities
{
    public class Track
    {
        public List<Talk> MorningSesion { get; set; }
        public List<Talk> AfternoonSession { get; set; }
    }
}