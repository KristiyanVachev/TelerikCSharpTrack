using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public string Model
        {
            get { return this.model; }
            protected set
            {
                //Model cannot be empty, null or with less than 3 symbols.
                if (string.IsNullOrEmpty((value)))
                {
                    throw new ArgumentException("Model cannot be empty or null.");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Model lenght cannot be less than 3 symbols");
                }
                this.model = value;
            }
        }

        public string Material
        {
            get { return this.material; }
            set { this.material = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                //•	Price cannot be less or equal to $0.00.  
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to $0.00.");
                }
                this.price = value;
            }
        }

        public virtual decimal Height
        {
            get { return this.height; }
            protected set
            {
                //Height cannot be less or equal to 0.00 m.
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00 m.");
                }
                this.height = value;
            }
        }
    }
}
