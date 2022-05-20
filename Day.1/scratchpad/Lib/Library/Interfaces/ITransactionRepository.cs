using Library.Day2.Bank;

namespace Tests.Day2.Bank {
    public interface ITransactionRepository {
        List<Transaction> GetTransactions();
        void CreateTransaction(Transaction transaction);
    }
}