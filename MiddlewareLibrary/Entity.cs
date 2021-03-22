using System;

namespace MiddlewareLibrary
{
    public abstract class Entity : IEntity
    {
        public string ID { get; protected init; }

        public Entity()
        {
            Console.WriteLine($"{GetType().Name} created");
            ID = CreateID();
        }

        public abstract void DisplayName();

        protected virtual string CreateID()
        {
            return $"{GetType().Name.ToLower()}-{Guid.NewGuid()}";
        }
    }
}