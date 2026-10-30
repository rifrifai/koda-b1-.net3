using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;

// Account budi = new SavingAccount("AC001", "Budi", 1000_000);
// CurrentAccount ahmad = new("AC002", "Ahmad", 500_000);
// ahmad.IsActive = false;

List<Account> accounts =
[
	new SavingAccount("ACC001", "Andi", 500_000, true),
	new CurrentAccount("ACC002", "Budi", 750_000, true),
	new SavingAccount("ACC003", "Dina", 250_000, false),
	new CurrentAccount("ACC004", "Satrio", 1000_000, true),
];

Console.WriteLine("===== Tampilkan Rek Aktif =====");
var activedAcc = accounts.Where(acc => acc.IsActive).ToList();
foreach(var acc in activedAcc)
{
	Console.WriteLine($"{acc.Name} - Aktif: {acc.IsActive}");
}

Console.WriteLine("===== Urutkan aktif dari saldo terbesar =====");
var mostBalance = accounts.Where(acc => acc.IsActive).OrderByDescending(acc => acc.Balance).ToList();
foreach(var acc in mostBalance)
{
	Console.WriteLine($"{acc.Name} - Balance: {acc.Balance:N0}" );
}

Console.WriteLine("===== Tampilkan nama seluruh account =====");
var getName = accounts.Select(acc => acc.Name).ToList();
foreach(var acc in getName)
{
	Console.WriteLine($"{acc}");
}

Console.WriteLine("===== Hitung total saldo =====");
var totalSaldo = accounts.Sum(acc => acc.Balance);
Console.WriteLine($"total keseluruhan balance: {totalSaldo:N0}");

Console.WriteLine("===== Cari AccountID ACC005 =====");
var queryService = new AccountQueryService(accounts);

Task<Account?> acc1 = queryService.FindAccountAsync("ACC005");
Task<Account?> acc2 = queryService.FindAccountAsync("ACC004");

Account?[] results = await Task.WhenAll(acc1, acc2)got;
foreach(var acc in results)
{
	Console.WriteLine(acc?.GetInformation() ?? "ACCOUNT NOT FOUND!");
}


// Console.WriteLine("Data Awal");
// Console.WriteLine($"{budi.Name} - Balance: {budi.Balance}");
// Console.WriteLine($"{ahmad.Name} - Balance: {ahmad.Balance}");

// ITransferService transfer = new TransferService();

// transfer.Transfer(budi, ahmad, 100000);

// Console.WriteLine("Data setelah Transfer");
// Console.WriteLine($"{budi.Name} - Balance: {budi.Balance}");
// Console.WriteLine($"{ahmad.Name} - Balance: {ahmad.Balance}");
