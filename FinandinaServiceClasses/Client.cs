using System;

namespace FinandinaServiceClasses
{
    /// <summary>
    /// Summary description for Client
    /// </summary>
    public class Client
    {
        public Client() => Oid = Guid.NewGuid();

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid Oid { get; }
    }
}