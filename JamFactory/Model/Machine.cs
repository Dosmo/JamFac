using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Machine {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double ScrapValue { get; set; }
        public double AuquistionValue { get; set; }
        public DateTime LifeTime { get; set; }
        public Machine(string Name, int Capacity, double ScrapValue, double AuquistionValue, DateTime LifeTimeW) {
            this.Name = Name;
            this.Capacity = Capacity;
            this.ScrapValue = ScrapValue;
            this.AuquistionValue = AuquistionValue;
            this.LifeTime = LifeTimeW;
        }
    }
}
