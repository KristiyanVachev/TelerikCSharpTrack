namespace Bank_Accounts
{
    public class Account
    {
        //properties
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public double InterestRate { get; set; }

        //constructors
        public Account(Customer customer, decimal balalance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balalance;
            this.InterestRate = interestRate;
        }

        //methods
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual double InterestAmount(int months)
        {
            return months * this.InterestRate;
        }
    }
}
