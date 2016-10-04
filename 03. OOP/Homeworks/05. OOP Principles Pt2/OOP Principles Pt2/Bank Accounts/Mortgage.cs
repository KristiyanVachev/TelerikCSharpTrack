namespace Bank_Accounts
{
    class Mortgage : Account
    {
        //fiels
        private const int companyMonthsNoInterest = 12;
        private const int individualsMonthsNoInterest = 6;

        //constructor
        public Mortgage(Customer customer, decimal balalance, double interestRate) : base(customer, balalance, interestRate)
        {
        }

        //methods
        //TO-DO - Repeated code in Loan
        public override double InterestAmount(int months)
        {
            int monthsWithNoInterest;
            if (this.Customer.GetType().Name.Equals("Company"))
            {
                monthsWithNoInterest = companyMonthsNoInterest;
            }
            else //Account held by individual
            {
                monthsWithNoInterest = individualsMonthsNoInterest;
            }


            if (months <= monthsWithNoInterest)
            {
                //No interest for the first 6/12 months
                return 0;
            }
            else
            {
                return this.InterestRate * (months - monthsWithNoInterest);
            }
        }
    }
}
