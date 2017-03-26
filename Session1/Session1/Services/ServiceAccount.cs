using Session1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session1.Services
{
    public class ServiceAccount
    {
        public string Create(string firstName, string lastName, string userName, string password)
        {
            Account account = new Account();

            account.FirstName = firstName;
            account.LastName = lastName;
            account.UserName = userName;
            account.Password = password;

            StoreData.listAccounts.Add(account);

            return account.Id;
        }

        public void Create(Account model)
        {
            StoreData.listAccounts.Add(model);
        }

        public Account Edit(string accountId, string firstName, string lastName, string userName, string password)
        {
            var account = FindById(accountId);

            if (account == null)
            {
                Console.WriteLine($"wrong account Id {accountId}");
            }
            else
            {
                account.FirstName = firstName;
                account.LastName = lastName;
                account.UserName = userName;
                account.Password = password;
            }

            return FindById(accountId);
        }

        public void Delete(string accountId)
        {
            var account = FindById(accountId);

            if (account == null)
            {
                Console.WriteLine($"wrong account Id {accountId}");
            }
            else
            {
                StoreData.listAccounts.Remove(account);
            }
        }

        public Account FindById(string id)
        {
            return StoreData.listAccounts.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Account> FindAll()
        {
            return StoreData.listAccounts;
        }
    }
}
