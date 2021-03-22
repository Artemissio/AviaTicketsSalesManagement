using System.Collections.Generic;

namespace MiddlewareLibrary
{
    public interface IBookingSystem
    {
        IReadOnlyList<Endpoint> Endpoints { get; }
        IReadOnlyList<Flight> Flights { get; }

        void AddEndpoint(Endpoint endpoint);
        void AddFlight(Flight flight);
        void AddPlane(Plane plane);
        void ChangeUserSettings(string id, User user);
        void EditEndpoint(string id, Endpoint endpoint);
        void EditFlight(string id, Flight flight);
        void EditPlane(string id, Plane plane);
        Flight GetFlight(int index);
        Flight GetFlight(string id);
        List<Flight> GetFlightByDestination(Endpoint destination);
        List<Flight> GetFlightsByDeparture(Endpoint departure);
        List<Plane> GetPlanesByFlight(string flightId);
        User Login(string login, string password);
        void Register(User user);
        void RemoveEndpoint(string id);
        void RemoveFlight(string id);
        void RemovePlane(string planeId);
    }
}