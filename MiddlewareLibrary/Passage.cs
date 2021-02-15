using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLibrary
{
    public class Passage : Entity
    {
        public string Name { get; set; }   
        public Endpoint Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public Endpoint Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public List<WayPoint> Route { get; }

        public Passage()
        {
            ID = "passage-" + Guid.NewGuid().ToString();
            Route = new List<WayPoint>();
        }

        public Passage(string name = null) : this()
        {
            Name = name;
        }

        public Passage(string name, Endpoint destination, DateTime destinationTime) : this(name)
        {
            Destination = destination;
            DestinationTime = destinationTime;
        }

        public Passage(string name, Endpoint destination, DateTime destinationTime, Endpoint departure, DateTime departureTime) 
                      : this(name, destination, destinationTime)
        {
            Departure = departure;
            DepartureTime = departureTime;
        }

        public Passage(string name, Endpoint destination, DateTime destinationTime, Endpoint departure, DateTime departureTime, List<WayPoint> route)
                      : this(name, destination, destinationTime, departure, departureTime)
        {
            Route = route;
        }

        public void AddWayPoint(Endpoint endpoint, DateTime transitionTime)
        {
            var waypoint = new WayPoint(this, endpoint, transitionTime);
            Route.Add(waypoint);
        }

        public void RemoveWayPoint(string id)
        {
            var wayPoint = Route.FirstOrDefault(x => x.ID == id);
            Route.Remove(wayPoint);
        }
    }
}
