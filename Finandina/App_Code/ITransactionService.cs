using FinandinaServiceClasses;
using System.ServiceModel;

namespace TransactionServiceContracts
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract(Name = "CreateTransference")]
        string CreateTransference(TransferenceParameters parameters);

        [OperationContract(Name = "GetTransferencesByClient")]
        string GetTransferencesByClient(int clientID);

        [OperationContract(Name = "GetTransferencesByAccount")]
        string GetTransferencesByAccount(int accountNumber);

        [OperationContract(Name = "UpdateTransference")]
        string UpdateTransference(UpdateTransferenceParameters parameters);

        [OperationContract(Name = "DeleteTransference")]
        string DeleteTransference(int transferenceNumber);
    }
}