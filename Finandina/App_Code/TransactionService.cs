using FinandinaServiceClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TransactionServiceContracts;

public class TransactionService : ITransactionService
{
    public string CreateTransference(TransferenceParameters parameters)
    {
        try
        {
            DatabaseManager DatabaseManager = new DatabaseManager();

            List<string> QueryRecords = DatabaseManager.ExecuteQuery("SELECT COUNT(*) FROM Transference");
            int NumberOfRecords = 0;

            if (QueryRecords.Any()) NumberOfRecords = int.Parse(QueryRecords[0].Trim());

            DatabaseManager.ExecuteCommand(
                string.Format("INSERT INTO Transference (Number, [Value], [Date], OriginAccountNumber, TargetAccountNumber, Oid)" +
                              "VALUES ({0}, {1}, '{2}', {3}, {4}, '{5}')",
                              NumberOfRecords + 1,
                              parameters.Value.ToString(CultureInfo.CreateSpecificCulture("en-GB")),
                              DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                              parameters.OriginAccountNumber,
                              parameters.TargetAccountNumber,
                              Guid.NewGuid().ToString()));

            return "Transferencia creada con éxito";
        }
        catch
        {
            return "Error inesperado en la creación de Transferencia.";
        }
    }

    public string DeleteTransference(int transferenceNumber)
    {
        try
        {
            DatabaseManager DatabaseManager = new DatabaseManager();

            DatabaseManager.ExecuteCommand(string.Format("DELETE FROM Transference WHERE Number = {0}", transferenceNumber));

            return "Transferencia eliminada con éxito";
        }
        catch
        {
            return "Error inesperado en la eliminación de Transferencia.";
        }
    }

    public string GetTransferencesByAccount(int accountNumber)
    {
        try
        {
            DatabaseManager DatabaseManager = new DatabaseManager();
            List<string> QueryRecords = DatabaseManager.ExecuteQuery(
                string.Format("SELECT * FROM Transference WHERE OriginAccountNumber = {0}", accountNumber));

            return string.Join(Environment.NewLine, QueryRecords);
        }
        catch
        {
            return "Error inesperado en la búsqueda de Transferencias por cuenta bancaria.";
        }
    }

    public string GetTransferencesByClient(int clientID)
    {
        try
        {
            DatabaseManager DatabaseManager = new DatabaseManager();
            string AccountNumber = string.Empty;

            List<string> QueryRecords = DatabaseManager.ExecuteQuery(
                string.Format("SELECT TOP 1 Number FROM Account " +
                              "INNER JOIN Client ON Client.Oid = Account.Client " +
                              "WHERE Client.ID = {0}", clientID));

            if (QueryRecords.Any())
                AccountNumber = QueryRecords[0].Trim();

            QueryRecords = DatabaseManager.ExecuteQuery(
                string.Format("SELECT * FROM Transference WHERE OriginAccountNumber = {0}", AccountNumber));

            return string.Join(Environment.NewLine, QueryRecords);
        }
        catch
        {
            return "Error inesperado en la búsqueda de Transferencias por cliente.";
        }
    }

    public string UpdateTransference(UpdateTransferenceParameters parameters)
    {
        try
        {
            DatabaseManager DatabaseManager = new DatabaseManager();

            DatabaseManager.ExecuteCommand(
                string.Format("UPDATE Transference " +
                              "SET [Value] = {0}, " +
                              "    [Date] = '{1}', " +
                              "    OriginAccountNumber = {2}, " +
                              "    TargetAccountNumber = {3} " +
                              "WHERE Number = {4}",
                              parameters.Value.ToString(CultureInfo.CreateSpecificCulture("en-GB")),
                              parameters.Date.ToString("dd/MM/yyyy HH:mm:ss"),
                              parameters.OriginAccountNumber,
                              parameters.TargetAccountNumber,
                              parameters.TransactionNumber));

            return "Transferencia actualizada con éxito";
        }
        catch
        {
            return "Error inesperado en la actualización de Transferencia.";
        }
    }
}