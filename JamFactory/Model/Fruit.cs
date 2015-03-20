using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Fruit:Ingredient
    {
        public double Gram { get; set; }
        public string Season { get; set; }
        public Fruit(string Name, double Price, int Amount, double Gram, string Season) : base(Name, Price, Amount)
        {
            this.Name = Name;
            this.Price = Price;
            this.Amount = Amount;
            this.Gram = Gram;
            this.Season = Season;
        }
    }
    
}
