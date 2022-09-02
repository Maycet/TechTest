using System;

namespace FinandinaServiceClasses
{
    /// <summary>
    /// Summary description for Account
    /// </summary>
    public class Account
    {
        public Account() => Oid = Guid.NewGuid();

        public int Number { get; set; }

        public string Name { get; set; }

        public Bank Bank { get; set; }

        public Client Client { get; set; }

        public Guid Oid { get; }
    }
}