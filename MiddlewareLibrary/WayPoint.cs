using System;

namespace MiddlewareLibrary
{
    public class WayPoint : Entity
    {
        public Passage Passage { get; }
        public Endpoint Endpoint { get; }
        public DateTime TransitionTime { get; set; }

        public WayPoint()
        {
            ID = "waypoint-" + Guid.NewGuid().ToString();
        }

        public WayPoint(Passage passage, Endpoint endpoint, DateTime transitionTime) : this()
        {
            Passage = passage;
            Endpoint = endpoint;
            TransitionTime = transitionTime;
        }
    }
}