using System;

namespace MiddlewareLibrary
{
    public class Place : Entity
    {
        public Plane Plane { get; }
        public decimal Price { get; }
        public bool IsBooked { get; private set; }
        public bool IsBought { get; private set; }
        public User Customer { get; private set; }

        public Place() : base()
        {
            ID = "place-" + Guid.NewGuid().ToString();

            IsBooked = IsBought = false;
        }

        public Place(Plane place, decimal price) : this()
        {
            Plane = place;
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

        public void Buy(User user)
        {
            try
            {
                Book(user);
                IsBought = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CancelBooking()
        {
            Customer = null;
            IsBought = IsBooked = false;
        }
    }
}