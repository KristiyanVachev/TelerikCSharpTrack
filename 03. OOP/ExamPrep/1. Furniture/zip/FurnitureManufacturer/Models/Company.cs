using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Name cannot be less than 5 symbols long");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            protected set
            {
                if (value == null || value.Length != 10)
                {
                    throw new ArgumentException("Registration Number must be excatly 10 symbols");
                }

                //may not work
                foreach (var ch in value)
                {
                    if (ch < '0' && ch > '9')
                    {
                        throw new ArgumentException("RN must contain only digits.");
                    }
                }

                this.registrationNumber = value;

            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.furnitures; }
            private set { this.furnitures = value; }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(f => string.Equals(f.Model, model, StringComparison.CurrentCultureIgnoreCase));
        }

        public string Catalog()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                ));

            foreach (var furniture in Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model))
            {
                sb.AppendLine(furniture.ToString());
            }


            return sb.ToString().Trim();
        }
    }
}
