namespace GSM
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd, notSpecified
    }
    public class Battery
    {
        private string model;
        private ushort hoursIdle;
        private ushort hoursTalk;
        private BatteryType type;

        public Battery(string model)
        {
            this.model = model;
            hoursIdle = 0;
            hoursTalk = 0;
            type = BatteryType.notSpecified;
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk, BatteryType type)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.type = type;
        }
    }
}
