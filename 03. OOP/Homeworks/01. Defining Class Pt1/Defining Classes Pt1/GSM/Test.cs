using System;

namespace GSM
{
    class Test
    {
        static void Main()
        {
            GSM koala = new GSM("Alpuni", "Australia");
            //Console.WriteLine(koala.Model);
            ////koala.ToString();
            //GSMTest poop = new GSMTest();
            GSMCallHistoryTest ako = new GSMCallHistoryTest();
            ako.TestFunctionality();
        }
    }
}
