using Microsoft.AspNetCore.Mvc;
using Project_Person.Domain.Interfaces;
using Project_Person.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Person.Controllers
{
    [ApiController]
    [Route("persons/")]
        public class PersonsController : ControllerBase
        {
            private readonly IPersonManager _personManager;

            public PersonsController(IPersonManager personManager)
            {
                _personManager = personManager;
            }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _personManager.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest($"Person Id={id} not found.");
            }
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _personManager.GetAll();
            return Ok(result);
        }

        [HttpGet("search")]
            public IActionResult GetByFullName([FromQuery] string firstName, [FromQuery] string lastName)
            {
                var result = _personManager.GetByFullName(firstName, lastName);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                return BadRequest($"Person {firstName} {lastName} not found.");
                }
            }

            [HttpGet("pagination")]
            public IActionResult GetPagination([FromQuery] int skip, [FromQuery] int take)
            {
                var result = _personManager.GetPagination(skip, take);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest($"Data skip={skip} take={take} is not valid.");
                }
            }

            [HttpPost]
            public IActionResult Create([FromBody] PersonRequest request)
            {
                var result = _personManager.Create(request);
                return Ok(result);
            }

            [HttpPut("{id}")]
            public IActionResult Update([FromRoute] int id, [FromBody] PersonRequest request)
            {
                var result = _personManager.Update(request, id);
                if (result)
                {
                    return Ok("Success!");
                }
                else
                {
                    return BadRequest("Person is not valid");
                }
            }

            [HttpDelete("{id}")]
            public IActionResult Delete([FromRoute] int id)
            {
                var result = _personManager.Delete(id);
                if (result)
                {
                    return Ok("Success!");
                }
                else
                {
                    return BadRequest($"Person Id={id} not found.");
                }
            }
        }
    }
