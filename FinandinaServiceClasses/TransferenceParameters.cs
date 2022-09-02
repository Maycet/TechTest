using System;

namespace FinandinaServiceClasses
{
    /// <summary>
    /// Summary description for TransferenceParameters
    /// </summary>
    public class TransferenceParameters : ITransferenceParameters
    {
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public int OriginAccountNumber { get; set; }
        public int TargetAccountNumber { get; set; }
    }
}