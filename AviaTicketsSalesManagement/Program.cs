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

            _ = new BookingSystem();

            Console.ReadKey();
        }
    }
}