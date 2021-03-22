using MiddlewareLibrary;
using System;

namespace RailwayTicketsSalesManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t=== Avia Tickets Booking System ===");
            Console.WriteLine("Made by students of IA-71");
            Console.WriteLine("Artem Tarasenko, Julia Koval, Maxim Terentiev");

            Console.WriteLine(" ");
            Console.WriteLine("\tStarted creation of models: ");

            IBookingSystem bookingSystem = new BookingSystem();

            Console.WriteLine(" ");

            Console.WriteLine("\t=== Testing interfaces ===");

            Console.WriteLine("1. Creating endpoint: ");
            Entity entity = new Endpoint("Test");
            Console.WriteLine("ID: " + entity.ID);

            IEntity copy = entity;

            Console.WriteLine("2. Casting endpoint to Flight: ");
            entity = new Flight("Kyiv - Lviv");
            Console.WriteLine("Entity is now of type : " + entity.GetType().Name);
            Console.WriteLine("ID: " + entity.ID);

            Console.WriteLine("3. Entities are equal: " + copy.Equals(entity));

            Console.WriteLine("4. Casting back: ");
            entity = (Entity)copy;
            Console.WriteLine("Entity is now of type : " + entity.GetType().Name);
            Console.WriteLine("ID: " + entity.ID);

            Console.ReadKey();
        }
    }
}