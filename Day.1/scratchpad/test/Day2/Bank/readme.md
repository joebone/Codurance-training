# Acceptance test

Naming convention : xxxxFeature



```cs
public class AccountService {
	public void deposit(int amount);
	public void withdraw(int amount);
	public void printStatement();
}
```

Add a console test helper so that printStatement written to console

Add an abstraction for Database, Store it in memory

First :
* Set Date Mock, Deposit 1000
* Set Date Mock, Withdraw 100
* Set Date Mock, Deposit 500
* Get Statement


| Date  | Amount | Balance |
|-------|--------|---------|
| 10/04 |   500  | 1400    |
| 02/04 |  -100  |  900    |
| 01/04 |  1000  | 1000    |




