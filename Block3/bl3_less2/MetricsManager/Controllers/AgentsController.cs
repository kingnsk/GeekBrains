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
    public class AgentsController : ControllerBase
    {
        private readonly AgentInfoStorage agentHolder;
        
        public AgentsController(AgentInfoStorage agentHolder)
        {
            this.agentHolder = agentHolder;
        }
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            agentHolder.Values.Add(agentInfo);
            return Ok();
        }
        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
        [HttpGet("getAgents")]
        public IActionResult GetAgents()
        {
            //agentHolder.Values.Add(agentInfo);
            return Ok(agentHolder.Values);
        }
    }
}
