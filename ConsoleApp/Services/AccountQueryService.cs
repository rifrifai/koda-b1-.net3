using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp.Models;

namespace ConsoleApp.Services
{
	public class AccountQueryService(IReadOnlyList<Account> accounts)
	{
		private readonly IReadOnlyList<Account> _accounts = accounts;

		public async Task<Account?> FindAccountAsync(string accountID)
		{
			await Task.Delay(300);
			return _accounts.FirstOrDefault(acc => acc.AccountID == accountID);
		}
	}
}