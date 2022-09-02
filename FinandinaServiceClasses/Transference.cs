using System;

namespace FinandinaServiceClasses
{
    /// <summary>
    /// Summary description for Transference
    /// </summary>
    public class Transference
    {
        public Transference() => Oid = Guid.NewGuid();

        public int Number { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public Account OriginAccount { get; set; }

        public Account TargetAccount { get; set; }

        public Guid Oid { get; }
    }
}