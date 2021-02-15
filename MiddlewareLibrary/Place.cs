using System;

namespace MiddlewareLibrary
{
    public class Place : Entity
    {
        public Train Train { get; }
        public decimal Price { get; }
        public bool IsBooked { get; private set; }
        public User Customer { get; private set; }

        public Place()
        {
            ID = "place-" + Guid.NewGuid().ToString();
        }

        public Place(Train train, decimal price) : this()
        {
            Train = train;
            Price = price;
        }

        public void Book(User user)
        {
            if (IsBooked)
            {
                throw new Exception("This place is already booked");
            }
            else
            {
                Customer = user;
                IsBooked = true;
            }
        }

        public void CancelBooking()
        {
            Customer = null;
            IsBooked = false;
        }
    }
}