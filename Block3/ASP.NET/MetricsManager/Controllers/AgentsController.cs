using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;
using MetricsManager.DAL;
using MetricsManager.Models;

namespace MetricsManager.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
//        private readonly AgentInfoStorage _agentHolder;
        private readonly ILogger<AgentsController> _logger;
        private IWorkWithAgentRepository _agentRepository;

        public AgentsController(ILogger<AgentsController> logger, IWorkWithAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в AgentsController");
        }

        //public AgentsController(AgentInfoStorage agentHolder)
        //{
        //    this._agentHolder = agentHolder;
        //}
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] Agent agentInfo)
        {
            _agentRepository.Create(agentInfo);
           // _agentHolder.Values.Add(agentInfo);
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
            var response = _agentRepository.GetAll();
            _logger.LogInformation(2, $"");
            return Ok(response);
        }
    }
}
