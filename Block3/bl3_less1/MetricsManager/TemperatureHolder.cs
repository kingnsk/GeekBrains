using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class TemperatureHolder
    {
        public List<WeatherForecast> Values { get; set; }

        public TemperatureHolder()
        { 
            Values = new List<WeatherForecast>();
        }
    }
}
