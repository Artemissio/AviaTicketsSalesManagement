using System;

namespace MiddlewareLibrary
{
    public class Place : Entity
    {
        public Plane Plane { get; }
        public decimal Price { get; set; }
        public bool IsBooked { get; private set; }
        public bool IsBought { get; private set; }
        public User Customer { get; private set; }

        public Place() : base()
        {
            IsBooked = IsBought = false;
        }

        public static Place operator ++(Place place)
        {
            place.Price++;
            return place;
        }

        public static Place operator +(Place place, decimal add)
        {
            place.Price += add;
            return place;
        }

        public static Place operator !(Place place)
        {
            place.CancelBooking();
            return place;
        }

        public static bool operator >(Place a, Place b)
        {
            return a.Price > b.Price;
        }

        public static bool operator <(Place a, Place b)
        {
            return a.Price < b.Price;
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