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
        public IActionResult Create([FromQuery] string temperature, [FromQuery] DateTime? timeMeasure)
        {
            if (temperature==null)
                return BadRequest();
            if (timeMeasure == null)
                timeMeasure = DateTime.Now;
            var dataT = new WeatherForecast();
            dataT.TemperatureC = Convert.ToInt32(temperature);
            dataT.Date = timeMeasure;
            holder.Values.Add(dataT);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime? timeStart, [FromQuery] DateTime? timeEnd)
        {

            var tempValues=new List<WeatherForecast>();

            if (timeStart == null && timeEnd == null)
                return Ok(holder.Values);

            if (timeStart == null)
                return BadRequest();

            if (timeEnd == null)
                return BadRequest();

            foreach (var dataT in holder.Values)
            {
                if (dataT.Date >= timeStart && dataT.Date <=timeEnd)
                {
                    tempValues.Add(dataT);
                }
            }
            return Ok(tempValues);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string timeToUpdate, [FromQuery] string newTemperature)
        {
            foreach (var dataT in holder.Values)
            {
                if (dataT.Date.ToString().Contains(timeToUpdate))
                {
                    dataT.TemperatureC = Convert.ToInt32(newTemperature);
                    return Ok();
                }
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string timeToDelete)
        {
            int i=0;
            foreach (var dataT in holder.Values)
            {
                if (dataT.Date.ToString().Contains(timeToDelete))
                {
                    holder.Values.RemoveAt(i);
                    return Ok();
                }
                i++;
            }
            return Ok();
        }
    }
}
