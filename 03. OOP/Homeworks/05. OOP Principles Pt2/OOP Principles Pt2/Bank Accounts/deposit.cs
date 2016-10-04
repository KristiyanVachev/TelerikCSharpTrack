namespace Bank_Accounts
{
    using System;
    public class Deposit : Account
    {
        //constructors
        public Deposit(Customer customer, decimal balalance, double interestRate) : base(customer, balalance, interestRate)
        {
        }

        //methods
        public void Withdraw(decimal amount)
        {
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insificient funds");
            }
        }

        public override double InterestAmount(int months)
        {
            //no interest if ballance belofe 1000
            if (this.Balance < 1000)
            {
                return 0;
            }
            
            //if ballance is over 1000, calculate with the formula in the base class
            return base.InterestAmount(months);
        }
    }
}
