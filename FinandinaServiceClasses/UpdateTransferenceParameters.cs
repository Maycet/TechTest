using System;

namespace FinandinaServiceClasses
{
    /// <summary>
    /// Summary description for UpdateTransferenceParameters
    /// </summary>
    public class UpdateTransferenceParameters : IUpdateTransferenceParameters
    {
        public int TransactionNumber { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public int OriginAccountNumber { get; set; }
        public int TargetAccountNumber { get; set; }
    }
}