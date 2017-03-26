using Session1.Models;
using Session1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1
{
    class Program
    {
        static ServiceAccount _serviceAccount = new ServiceAccount();

        static void Main(string[] args)
        {
            bool isContinue = true;

            do
            {
                Console.Clear();

                Console.WriteLine("************** System Account **************");

                Console.WriteLine("Create Account Input 1: ");

                Console.WriteLine("Edit Account Input 2: ");

                Console.WriteLine("Find Account By Id Input 3: ");

                Console.WriteLine("Find All Account Input 4: ");

                Console.WriteLine("Delete Account Input 5: ");

                ProcessAction(Console.ReadLine());

                Console.WriteLine("Do you want continue [y/n]?");

                string str = Console.ReadLine().ToString().ToLower();

                isContinue = (str == "y" ? true : false);

            } while (isContinue);

            Console.ReadKey();
        }

        private static void ProcessAction(string action)
        {
            switch (Convert.ToInt32(action))
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    EditAccount();
                    break;
                case 3:
                    FindAccountById();
                    break;
                case 4:
                    FindAllAccount();
                    break;
                case 5:
                    DeleteAccount();
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }

        private static void CreateAccount()
        {
            string firstName = string.Empty, lastName = string.Empty, userName = string.Empty, password = string.Empty;

            Console.WriteLine($"Total Record: {StoreData.listAccounts.Count().ToString()}");

            CommonFormInput(ref firstName, ref lastName, ref userName, ref password);

            string accountId = _serviceAccount.Create(firstName, lastName, userName, password);

            Console.WriteLine($"Account Id {accountId}");
        }

        private static void EditAccount()
        {
            string firstName = string.Empty, lastName = string.Empty, userName = string.Empty, password = string.Empty, accountId = string.Empty;

            Console.WriteLine($"Total Record: {StoreData.listAccounts.Count().ToString()}");

            Console.Write("Input AccountId: ");

            accountId = Console.ReadLine().ToString();

            CommonFormInput(ref firstName, ref lastName, ref userName, ref password);

             var account = _serviceAccount.Edit(accountId, firstName, lastName, userName, password);

            if(account !=null) ShowInfo(account);
        }

        private static void FindAccountById()
        {
            Console.Write("Input Account Id: ");

            string accountId = Console.ReadLine();

            if (string.IsNullOrEmpty(accountId))
            {
                Console.WriteLine("Account Id is not null.");
            }
            else
            {
                Account account = _serviceAccount.FindById(accountId);

                if (account == null)
                {
                    Console.WriteLine("Account Id incorrect");
                    return;

                }

                ShowInfo(account);
            }
        }

        private static void FindAllAccount()
        {
            var result = _serviceAccount.FindAll();

            foreach (var item in result)
            {
                ShowInfo(item);
            }
        }

        private static void DeleteAccount()
        {
            string accountId = string.Empty;

            Console.WriteLine($"Total Record: {StoreData.listAccounts.Count().ToString()}");

            Console.Write("Input AccountId: ");

            accountId = Console.ReadLine().ToString();

            _serviceAccount.Delete(accountId);
        }

        private static void ShowInfo(Account account)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine($"AccountId: {account.Id}");
            Console.WriteLine($"FirstName: {account.FirstName}");
            Console.WriteLine($"LastName: {account.LastName}");
            Console.WriteLine($"UserName: {account.UserName}");
            Console.WriteLine($"Password: {account.Password}");
        }

        private static void CommonFormInput(ref string firstName, ref string lastName, ref string userName, ref string password)
        {
            Console.Write("Input FirstName: ");

            firstName = Console.ReadLine().ToString();

            Console.Write("Input LastName: ");

            lastName = Console.ReadLine().ToString();

            Console.Write("Input UserName: ");

            userName = Console.ReadLine().ToString();

            Console.Write("Input Password: ");

            password = Console.ReadLine().ToString();
        }

    }
    
}
