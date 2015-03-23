using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    class Quality
    {
        public string Type { get; set; }
        public int BerriePercent {get; set;}
        public Quality(string Type, int BerriePercent) {
            this.Type = Type;
            this.BerriePercent = BerriePercent;
        }
    }
}
