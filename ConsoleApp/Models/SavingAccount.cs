using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Models;
public class SavingAccount(string accountID, string name, decimal balance, bool isActive) : Account(accountID, name, balance, isActive)
{
	
}