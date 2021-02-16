using System;

namespace MiddlewareLibrary
{
    public abstract class Entity
    {
        public string ID { get; protected init; }

        public Entity()
        {
            Console.WriteLine($"{GetType().Name} created");
        }
    }
}