namespace FinandinaServiceClasses
{
    public interface IUpdateTransferenceParameters : ITransferenceParameters
    {
        int TransactionNumber { get; set; }
    }
}