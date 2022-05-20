using Library.Interfaces;
using System.Text;
using Tests.Day2.Bank;

namespace Library.Day2.Bank;
public class AccountService {
    private ITransactionRepository transactionRepository;
    private readonly IConsole console;
    private readonly IDatetimeProvider datetimeProvider;

    public AccountService(IDatetimeProvider datetimeProvider, ITransactionRepository transactionRepository, IConsole console) {
        this.transactionRepository = transactionRepository;
        this.console = console;
        this.datetimeProvider = datetimeProvider;
    }

    public void Deposit(int amount) {
        transactionRepository.CreateTransaction(new Transaction(datetimeProvider.UtcNow, amount));
    }
    public void Withdraw(int amount) {
        transactionRepository.CreateTransaction(new Transaction(datetimeProvider.UtcNow, -amount));
    }
    public void PrintStatement() {

        StringBuilder sb = new();
        sb.AppendLine("| Date | Amount | Balance |");
        sb.AppendLine("|----------|--------|---------|");
        /*
         |----------|--------|---------|
| 2022-09-04 | 50 | 100 |
| 2022-09-01 | 50 | 0 |
         */

        int balance = 0;
        var tx = transactionRepository.GetTransactions().OrderBy(f => f.Date).ToArray();
        for (int i = 0; i < tx.Length; i++) {
            balance += tx[i].Amount;
        }

        Array.Reverse(tx);

        for (int i = 0; i < tx.Length; i++) {
            var line = tx[i];
            sb.Append("| ").AppendJoin(" | ", line.Date.ToString("yyyy-MM-dd"), line.Amount, balance).AppendLine(" |");
            balance -= line.Amount;
        }


        console.Print(sb.ToString());

        /*
| Date | Amount | Balance |
|----------|--------|---------|
| 3 | 1000 | 2050 |
| 2 | 50 | 1050 |
| 1 | -1000 | 0 |
| 0 | 1000 | 1000 |
        //console.Print()
        */
    }
}
