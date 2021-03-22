namespace MiddlewareLibrary
{
    public class Endpoint : Entity
    {
        public string Name { get; set; }

        public Endpoint() : base()
        {
            ID = string.Empty;
        }

        public Endpoint(string name) : this()
        {
            Name = name;

            ID = CreateID();
        }

        protected override string CreateID()
        {
            return $"endpoint-{Name}";
        }
    }
}