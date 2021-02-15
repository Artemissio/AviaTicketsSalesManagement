using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareLibrary
{
    public class Train : Entity
    {
        public Passage Passage { get; }
        public List<Place> Places { get; }

        public Train()
        {
            ID = "trains-" + Guid.NewGuid().ToString();
            Places = new List<Place>();
        }

        public Train(Passage passage) : this()
        {
            Passage = passage;
        }

        public Train(List<Place> places) : this()
        {
            Places = places;
        }

        public Train(Passage passage, List<Place> places) : this(passage)
        {
            Places = places;
        }

        public List<Place> GetFreePlaces()
        {
            return Places.Where(x => !x.IsBooked).ToList();
        }

        public List<Place> GetBookedPlaces()
        {
            return Places.Where(x => x.IsBooked).ToList();
        }
    }
}
