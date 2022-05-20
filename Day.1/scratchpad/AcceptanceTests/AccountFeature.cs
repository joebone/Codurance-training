using Library.Day2.Bank;
using Library.Interfaces;
using System.Text;
using Tests.Day2.Bank;

namespace AcceptanceTests;

public class AccountFeature {
    IConsole console;
    private IDatetimeProvider dateTimeProvider;
    private ITransactionRepository repo;

    StringBuilder sb;
    List<Transaction> transactions;
    public AccountFeature() {

        sb = new();
        console = Substitute.For<IConsole>();
        console.WhenForAnyArgs(f => f.Print(Arg.Any<string>())).Do(f => sb.Append(f.Args()[0]));

        console.Output().Returns(_ => sb.ToString());
        transactions = new();

        dateTimeProvider = Substitute.For<IDatetimeProvider>();
        repo = Substitute.For<ITransactionRepository>();
        repo.When(f => f.CreateTransaction(Arg.Any<Transaction>())).Do(x => transactions.Add(x.ArgAt<Transaction>(0)));
        repo.GetTransactions().Returns(x => transactions);
    }

    const string EXPECTED_OUTPUT =
@"| Date | Amount | Balance |
|----------|--------|---------|
| 2022-04-01 | 1000 | 1050 |
| 2022-03-01 | 50 | 50 |
| 2022-02-01 | -1000 | 0 |
| 2022-01-01 | 1000 | 1000 |
";

    [Fact]
    public void Can_Return_balance() {

        dateTimeProvider.UtcNow.Returns(new DateTime(2022, 1, 1));

        var srv = new AccountService(dateTimeProvider, repo, console);

        srv.Deposit(1000);
        dateTimeProvider.UtcNow.Returns(new DateTime(2022, 2, 1));
        srv.Withdraw(1000);
        dateTimeProvider.UtcNow.Returns(new DateTime(2022, 3, 1));
        srv.Deposit(50);
        dateTimeProvider.UtcNow.Returns(new DateTime(2022, 4, 1));
        srv.Deposit(1000);
        srv.PrintStatement();

        Assert.Single(console.ReceivedCalls());

        Assert.Equal(EXPECTED_OUTPUT, console.Output());
    }
}