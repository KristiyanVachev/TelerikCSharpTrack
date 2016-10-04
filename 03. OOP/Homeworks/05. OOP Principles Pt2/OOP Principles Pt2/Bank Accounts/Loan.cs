namespace Bank_Accounts
{
    class Loan : Account
    {
        //fields
        //no magic numbers
        private const int companyMonthsWithNoInterest = 3;
        private const int individualMontsWithNoInterest = 2;

        //constructors
        public Loan(Customer customer, decimal balalance, double interestRate) : base(customer, balalance, interestRate)
        {
        }

        //methods
        public override double InterestAmount(int months)
        {
            int monthsWithNoInterest;
            if (this.Customer.GetType().Name.Equals("Company"))
            {
                monthsWithNoInterest = companyMonthsWithNoInterest;
            }
            else //Account held by individual
            {
                monthsWithNoInterest = individualMontsWithNoInterest;
            }

            if (months <= monthsWithNoInterest)
            {
                //No interest for the first 3 months
                return 0;
            }
            else
            {
                return this.InterestRate * (months - monthsWithNoInterest);
            }

        }


    }
}
