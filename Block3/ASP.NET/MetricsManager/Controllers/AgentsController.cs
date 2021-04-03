using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly AgentInfoStorage agentHolder;

        private readonly ILogger<CpuMetricsController> _logger;

        public AgentsController(ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в AgentsController");
        }


        public AgentsController(AgentInfoStorage agentHolder)
        {
            this.agentHolder = agentHolder;
        }
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            agentHolder.Values.Add(agentInfo);
            _logger.LogInformation(2, $"Параметры: (AgentInfo:{agentInfo}");
            return Ok();
        }
        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation(2, $"Enabled: (AgentId:{agentId}");
            return Ok();
        }
        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation(2, $"Disabled: (AgentId:{agentId}");
            return Ok();
        }
        [HttpGet("getAgents")]
        public IActionResult GetAgents()
        {
            _logger.LogInformation(2, $"");
            //agentHolder.Values.Add(agentInfo);
            return Ok(agentHolder.Values);
        }
    }
}
