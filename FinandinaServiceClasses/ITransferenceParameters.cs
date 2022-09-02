using System;

namespace FinandinaServiceClasses
{
    public interface ITransferenceParameters
    {
        decimal Value { get; set; }

        DateTime Date { get; set; }

        int OriginAccountNumber { get; set; }

        int TargetAccountNumber { get; set; }
    }
}