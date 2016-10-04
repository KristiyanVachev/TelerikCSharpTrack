using System;
using System.Collections.Generic;

namespace GSM
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iPhone4S = new GSM("Iphone 4S", "Apple", 400, "Bill Gates", new Battery("HDED23", 24, 4, BatteryType.LiIon), new Display(4.2, 65000));
        private List<Call> callHistory = new List<Call>();

        //PROPERTIES
        public string Model
        {
            get
            { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid manufacturer!");
                }
                this.model = value;
            }
        }

        static public GSM IPhone4S { get; set; }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        //... won't do anymore of the the same properties unless used.
        //CONSTRUCTORS
        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display) :this(model, manufacturer)
        {
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }

        //METHODS
        public override string ToString()
        {
            Console.WriteLine("Model: {0}", this.model);
            Console.WriteLine("Manufacturer: {0}", this.manufacturer);
            Console.WriteLine("Price: {0}", this.price);
            Console.WriteLine("Owner: {0}", this.owner);
            return base.ToString();
        }

        public void AddCall(Call newCall)
        {
            this.callHistory.Add(newCall);
        }

        public void DeleteCall(int index)
        {
            this.callHistory.RemoveAt(index);
        }

        public void Clear()
        {
            this.callHistory.Clear();
        }

        public double CalculatePrice(double pricePerMinute)
        {
            double total = 0;
            foreach (var call in this.callHistory)
            {
               total += call.duration * (pricePerMinute / 60);
            }
            return total;
        }
    }
}
