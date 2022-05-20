using Library.Day2.Bank;
using Library.Interfaces;
using Moq;
using System.Text;

namespace Tests.Day2.Bank;
public class AccountService_should {
    private AccountService accountService;

    ITransactionRepository transactionRepository;
    private IDatetimeProvider dateTimeProvider;
    private readonly IConsole console;
    private List<Transaction> transactions;

    public AccountService_should() {
        transactions = new();
        transactionRepository = Substitute.For<ITransactionRepository>();
        transactionRepository.When(f => f.CreateTransaction(Arg.Any<Transaction>())).Do(x => transactions.Add(x.ArgAt<Transaction>(0)));
        transactionRepository.GetTransactions().Returns(x => transactions);


        dateTimeProvider = Substitute.For<IDatetimeProvider>();
        dateTimeProvider.UtcNow.Returns(new DateTime(1, 1, 1));
        dateTimeProvider.Now.Returns(new DateTime(1, 1, 1));

        console = Substitute.For<IConsole>();


        accountService = new AccountService(dateTimeProvider, transactionRepository, console);
    }

    [Fact]
    public void deposit_inserts_to_the_repository() {
        var transactionRepository = new Mock<ITransactionRepository>();
        var expectedTransaction = new Transaction(dateTimeProvider.UtcNow, 100);
        accountService = new AccountService(dateTimeProvider, transactionRepository.Object, console);
        accountService.Deposit(100);
        transactionRepository.Verify(v => v.CreateTransaction(expectedTransaction), Times.Once, "Transaction was not inserted.");
    }

    [Fact]
    public void withdraw_inserts_a_negative_transaction_to_its_repository() {
        var transactionRepository = new Mock<ITransactionRepository>();
        var expectedTransaction = new Transaction(dateTimeProvider.UtcNow, -100);
        accountService = new AccountService(dateTimeProvider, transactionRepository.Object, console);
        accountService.Withdraw(100);
        transactionRepository.Verify(v => v.CreateTransaction(expectedTransaction), Times.Once, "Transaction was not inserted.");

    }

    [Fact]
    public void print_balance_delegates_to_its_inner() {
        var expectedTransaction = new Transaction(dateTimeProvider.UtcNow, -100);
        accountService = new AccountService(dateTimeProvider, transactionRepository, console);
        accountService.PrintStatement();
        console.ReceivedWithAnyArgs(1).Print(null);
    }

    [Fact]
    public void prints_an_empty_statement_if_no_transactions() {

        const string EXPECTEDOUTPUT =
@"| Date | Amount | Balance |
|----------|--------|---------|
";
        StringBuilder testOutput = new();
        console.When(c => c.Print(Arg.Any<string>())).Do(x => testOutput.Append(x.ArgAt<string>(0)));

        accountService = new AccountService(dateTimeProvider, transactionRepository, console);
        accountService.PrintStatement();

        Assert.Equal(EXPECTEDOUTPUT, testOutput.ToString());

    }

    [Fact]
    public void prints_transactions_in_reverse_order() {

        const string EXPECTEDOUTPUT =
@"| Date | Amount | Balance |
|----------|--------|---------|
| 2022-09-04 | 50 | 100 |
| 2022-09-01 | 50 | 50 |
";
        StringBuilder testOutput = new();
        console.When(c => c.Print(Arg.Any<string>())).Do(x => testOutput.Append(x.ArgAt<string>(0)));

        accountService = new AccountService(dateTimeProvider, transactionRepository, console);

        dateTimeProvider.UtcNow.Returns(new DateTime(2022, 9, 1));
        accountService.Deposit(50);
        dateTimeProvider.UtcNow.Returns(new DateTime(2022, 9, 4));
        accountService.Deposit(50);

        accountService.PrintStatement();

        Assert.Equal(EXPECTEDOUTPUT, testOutput.ToString());
    }
}
