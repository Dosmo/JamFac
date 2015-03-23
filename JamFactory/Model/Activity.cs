using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    public class Activity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public DateTime Time { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }

        public Activity(string title, string description, string details, DateTime time, string expectedResult, string actualResult)
        {
            this.Title = title;
            this.Description = description;
            this.Details = details;
            this.Time = time;
            this.ExpectedResult = ExpectedResult;
            this.ActualResult = actualResult;
        }
    }
}
