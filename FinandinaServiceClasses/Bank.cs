using System;

namespace FinandinaServiceClasses
{
    /// <summary>
    /// Summary description for Bank
    /// </summary>
    public class Bank
    {
        public Bank() => Oid = Guid.NewGuid();

        public string Name { get; set; }
        public Guid Oid { get; }
    }
}