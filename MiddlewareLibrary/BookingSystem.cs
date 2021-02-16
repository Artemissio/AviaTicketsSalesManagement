using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareLibrary
{
    public class BookingSystem
    {
        public IReadOnlyList<Flight> Flights => _flights.AsReadOnly();

        private readonly List<Flight> _flights;
        private readonly List<Plane> _planes;
        private readonly List<User> _customers;

        public BookingSystem()
        {
            _flights = new List<Flight>();
            _planes = new List<Plane>();
            _customers = new List<User>();
        }

        public Flight GetFlight(int index)
        {
            return _flights[index];
        }

        public Flight GetFlight(string id)
        {
            return _flights.First(x => x.ID == id);
        }

        public void AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }

        public void RemoveFlight(string id)
        {
            var flight = _flights.FirstOrDefault(x => x.ID == id);

            if (flight is not null)
            {
                _flights.Remove(flight);

                GetPlanesByFlight(id).ForEach(x => RemovePlane(x.ID));
            }
        }

        public void EditFlight(string id, Flight flight)
        {
            RemoveFlight(id);
            AddFlight(flight);
        }

        public List<Flight> GetFlightsByDeparture(Endpoint departure)
        {
            return _flights.Where(x => x.Departure == departure).ToList();
        }

        public List<Flight> GetFlightByDestination(Endpoint destination)
        {
            return _flights.Where(x => x.Destination == destination).ToList();
        }

        public void AddPlane(Plane plane)
        {
            _planes.Add(plane);
        }

        public void RemovePlane(string planeId)
        {
            var plane = _planes.FirstOrDefault(x => x.ID == planeId);

            if (plane is not null)
            {
                _planes.Remove(plane);
            }
        }

        public void EditPlane(string id, Plane plane)
        {
            RemovePlane(id);
            AddPlane(plane);
        }

        public List<Plane> GetPlanesByFlight(string flightId)
        {
            var flight = GetFlight(flightId);

            if (flight is null)
            {
                throw new Exception("This passage does not exist");
            }

            return _planes.Where(x => x.Flight.ID == flightId).ToList();
        }

        public void Register(User user)
        {
            if (_customers.Any(x => x.Login == user.Login))
            {
                throw new Exception($"User with login '{user.Login}' already exists");
            }

            _customers.Add(user);
        }

        public User Login(string login, string password)
        {
            var user = _customers.FirstOrDefault(x => x.Login == login);

            if (user is null)
            {
                throw new Exception($"There is no customer with login '{login}'");
            }

            if (user.Password != password)
            {
                throw new Exception("Password is incorrect");
            }

            return user;
        }

        public void ChangeUserSettings(string id, User user)
        {

        }
    }
}