using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Recipe {
        public string Name { get; set; }
        public string Documentation { get; set; }
        public string Correspondence { get; set; }
        public List<Product> Products { get; set; }

        public Recipe(string Name, string Documentation, string Correspondence) {
            this.Name= Name;
            this.Documentation = Documentation;
            this.Correspondence = Correspondence;
            this.Products = new List<Product>();
        }
    }
}
