using System;

namespace MiddlewareLibrary
{
    public class Endpoint : Entity
    {
        public string Name { get; set; }

        public Endpoint() : base()
        {
            ID = "endpoint-" + Guid.NewGuid().ToString();
        }

        public Endpoint(string name) : this()
        {
            Name = name;
        }
    }
}