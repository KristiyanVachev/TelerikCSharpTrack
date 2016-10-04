namespace Bank_Accounts
{
    using System;
    using System.Collections.Generic;

    class Statup
    {
        static void Main()
        {
            Individual elonMusk = new Individual("Elon Musk");
            Company tesla = new Company("Tesla");
            Company spaceX = new Company("SpaceX");
            Company solarCity = new Company("Solar City");

            //InterestAmount test
            List<Account> accounts = new List<Account>()
            {
                new Loan(tesla, 1000, 0.2),
                new Deposit(elonMusk,12300000,0.8), //he really has 12,3 billion USD 
                new Mortgage(solarCity, 1000000,1)
            };

            foreach (var account in accounts)
            {
                Console.WriteLine("Interest amount for a {2} {1} for 18 months: {0}",account.InterestAmount(18),account.GetType().Name);
            }
            
            //Deposit withdraw test
            Deposit deposit = new Deposit(elonMusk, 2000, 1);
            Console.WriteLine("Deposit ballance before withdraw: {0}$",deposit.Balance);
            deposit.Withdraw(1200);
            Console.WriteLine("Deposit ballance after withdraw: {0}$", deposit.Balance);
        }
    }
}
