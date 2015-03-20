using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    public class Employee : Person {
        public int ID { get; set; }
        public string Password { get; set; }
        public DateTime Hired { get; set; }

        public Employee(int ID, string Password, DateTime Hired, string Name) {
            this.ID = ID;
            this.Password = Password;
            this.Hired = Hired;
            this.Name = Name;
        }
    }
}
