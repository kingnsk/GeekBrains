using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly TemperatureHolder holder;

        public CrudController(TemperatureHolder holder)
        {
            this.holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] int? temperature, [FromQuery] DateTime? timeMeasure)
        {
            if (temperature==null)
                return BadRequest();
            if (timeMeasure == null)
                timeMeasure = DateTime.Now;
            var weather = new WeatherForecast();
            weather.TemperatureC = Convert.ToInt32(temperature);
            weather.Date = timeMeasure;
            holder.Values.Add(weather);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime? timeStart, [FromQuery] DateTime? timeEnd)
        {
            var selectedValues=new List<WeatherForecast>();

            if (timeStart == null && timeEnd == null)
                return Ok(holder.Values);

            if (timeStart == null)
            {
                foreach (var dataWeather in holder.Values)
                {
                    if (dataWeather.Date <= timeEnd)
                    {
                        selectedValues.Add(dataWeather);
                    }
                }
                return Ok(selectedValues);
            }

            if (timeEnd == null)
            {
                foreach (var dataWeather in holder.Values)
                {
                    if (dataWeather.Date >= timeStart)
                    {
                        selectedValues.Add(dataWeather);
                    }
                }
                return Ok(selectedValues);
            }

            foreach (var dataWeather in holder.Values)
            {
                if (dataWeather.Date >= timeStart && dataWeather.Date <=timeEnd)
                {
                    selectedValues.Add(dataWeather);
                }
            }
            return Ok(selectedValues);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime timeToUpdate, [FromQuery] int newTemperature)
        {
            foreach (var dataWeather in holder.Values)
            {
                if (dataWeather.Date.ToString().Contains(timeToUpdate.ToString()))
                {
                    dataWeather.TemperatureC = newTemperature;
                    return Ok();
                }
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime timeToDelete)
        {
            for (int i = 0; i < holder.Values.Count; i++)
            {
                if (holder.Values[i].Date.ToString().Contains(timeToDelete.ToString()))
                {
                    holder.Values.RemoveAt(i);
                }
            }
            return Ok();
        }
    }
}
