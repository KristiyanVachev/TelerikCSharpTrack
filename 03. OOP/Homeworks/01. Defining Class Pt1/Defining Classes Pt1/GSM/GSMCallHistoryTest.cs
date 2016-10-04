using System;

namespace GSM
{
    public class GSMCallHistoryTest
    {
        private GSM phone = new GSM("S", "Tesla");
        private double pricePerMinute = 0.37;

        public void TestFunctionality()
        {
            //Add calls
            phone.AddCall(new Call(32));
            phone.AddCall(new Call(28));
            phone.AddCall(new Call(60));

            //TO-DO
            //Print call info

            //Price
            Console.WriteLine("Total price: {0}", phone.CalculatePrice(pricePerMinute));

            //find longest call
            int best = 0;
            int bestInd = 0;
            for (int i = 0; i < phone.CallHistory.Count; i++)
            {
                if (phone.CallHistory[i].duration > best)
                {
                    best = phone.CallHistory[i].duration;
                    bestInd = i;
                }
            }
            phone.DeleteCall(bestInd);
            Console.WriteLine("Price whitout the longest call: {0}", phone.CalculatePrice(pricePerMinute));

            //Clear
            phone.CallHistory.Clear();
            //TO-DO 
            phone.CallHistory.ToString();

        }
    }
}
