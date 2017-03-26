using Session1.Models;
using System.Collections.Generic;

namespace Session1
{
    public static class StoreData
    {
        public static IList<Account> listAccounts = new List<Account>();
        public static IList<Customer> listCustomers = new List<Customer>();
    }
}
