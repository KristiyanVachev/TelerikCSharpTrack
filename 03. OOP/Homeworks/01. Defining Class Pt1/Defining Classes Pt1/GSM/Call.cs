using System;

namespace GSM
{
    public class Call
    {
        private DateTime date;
        private DateTime time;
        private string dialedPhone;
        //private int duration;

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string DialedPhone { get; set; }
        //public int Duration
        //{
        //    get { return this.duration; }
        //    set { this.duration = value; }
        //}
        public int duration { get; set; }

        public Call(int duration)
        {
            this.duration = duration;
        }

        public Call(DateTime date, DateTime time, string dialedPhone, int duration) : this(duration)
        {
            this.date = date;
            this.time = time;
            this.dialedPhone = dialedPhone;
        }
    }
}
