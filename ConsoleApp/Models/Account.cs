using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Models;
public abstract class Account
{
	public string AccountID { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public decimal Balance { get; protected set; }
	public bool IsActive { get; set; }

	public Account(string accountID, string name, decimal balance, bool isActive)
	{
		if (string.IsNullOrWhiteSpace(accountID))
			throw new ArgumentException("AccountID harus diisi");
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Nama harus diisi");
		if (balance < 0)
			throw new ArgumentException("Saldo harus lebih besar dari 0");
		AccountID = accountID;
		Name = name;
		Balance = balance;
		IsActive = isActive;
	}
	public void Debit(decimal amout)
	{
		Balance -= amout;
	}

	public void Credit(decimal amout)
	{
		Balance += amout;
	}
	public string GetInformation()
	{
		return $"AccountID: {AccountID}, Name: {Name}, Balance: {Balance:N0}, Active: {IsActive}";
	}
}