using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareLibrary
{
    public class Flight : Entity
    {
        public string Name { get; set; }   
        public Endpoint Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public Endpoint Departure { get; set; }
        public DateTime DepartureTime { get; set; }

        public Flight() : base()
        {
            ID = "passage-" + Guid.NewGuid().ToString();
        }

        public Flight(string name) : this()
        {
            Name = name;
        }

        public Flight(string name, Endpoint destination, DateTime destinationTime) : this(name)
        {
            Destination = destination;
            DestinationTime = destinationTime;
        }

        public Flight(string name, Endpoint destination, DateTime destinationTime, Endpoint departure, DateTime departureTime) 
                      : this(name, destination, destinationTime)
        {
            Departure = departure;
            DepartureTime = departureTime;
        }
    }
}