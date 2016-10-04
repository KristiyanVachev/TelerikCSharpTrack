namespace GSM
{
    public class GSMTest
    {
        private GSM[] phones = {
             new GSM("Iphone 4S", "Apple", 400, "Bill Gates", new Battery("HDED23", 24, 4, BatteryType.LiIon), new Display(4, 65000)),
             new GSM("Galaxy Ace", "Samsung", 200, "Chu Huan", new Battery("HIDND", 24, 4, BatteryType.LiIon), new Display(4.2, 80000)),
             new GSM("A425d", "Lenovo", 230, "Will Hunting", new Battery("SSDID", 28, 5, BatteryType.LiIon), new Display(5, 134000))
         }; 

        public void DisplayInfo()
        {
            foreach (var phone in phones)
            {
                phones.ToString();
            }

            GSM.IPhone4S.ToString();
        }
    }

}
