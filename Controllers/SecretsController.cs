using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baalmy.Models;
using baalmy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace baalmy.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  class SecretsController : ControllerBase
  {
    private readonly SecretsRepository _repo;

    public SecretsController(SecretsRepository repo)
    {
      _repo = repo;
    }
    [HttpGet("{id}")]
    public ActionResult<Secret> Get(string id)
    {
      return Ok(_repo.GetForUser(id));
    }
    [HttpPost]
    public ActionResult<Secret> Post([FromBody] Secret value)
    {
      Secret answer = _repo.CreateSecret(value);
      return Created("/api/secret/" + answer.Id, answer);
    }
  }
}