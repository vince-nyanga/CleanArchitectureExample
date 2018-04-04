using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WeatherEntity
    {
        public string Description { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }

    }
}
