using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareLibrary
{
    public class Plane : Entity
    {
        public Flight Flight { get; }

        private List<Place> _places;

        public Plane() : base()
        {
            ID = "trains-" + Guid.NewGuid().ToString();
            _places = new List<Place>();
        }

        public Plane(Flight flight) : this()
        {
            Flight = flight;
        }

        public Plane(List<Place> places) : this()
        {
            _places = places;
        }

        public Plane(Flight flight, List<Place> places) : this(flight)
        {
            _places = places;
        }

        public IReadOnlyList<Place> GetPlaces()
        {
            return _places.AsReadOnly();
        }

        public List<Place> GetFreePlaces()
        {
            return _places.Where(x => !x.IsBooked).ToList();
        }

        public List<Place> GetBookedPlaces()
        {
            return _places.Where(x => x.IsBooked).ToList();
        }
    }
}
