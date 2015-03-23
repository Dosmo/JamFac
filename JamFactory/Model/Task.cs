using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    class Task {
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Task(string Description, DateTime StartTime, DateTime EndTime) {
            this.Description = Description;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}
