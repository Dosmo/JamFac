using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    public class Control
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TimeCheck { get; set; }
        public List<Activity> Activitys { get; set; }
        public Model.Product Product { get; set; }
        public Model.Employee Employee { get; set; }

        public Control(string name, string description, string timeCheck)
        {
            this.Name = name;
            this.Description = description;
            this.TimeCheck = timeCheck;
            this.Activitys = new List<Activity>();
        }
    }
}
