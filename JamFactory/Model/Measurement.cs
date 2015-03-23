﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model
{
    public class Measurement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }

        public Measurement(string Name, string ExpectedResult)
        {
            this.Name = Name;
            this.ExpectedResult = ExpectedResult;
        }
    }
}
