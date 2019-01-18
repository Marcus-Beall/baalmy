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
    private readonly LibraryRepository _repo;

    public LibrarysController(LibraryRepository repo)
    {
      _repo = repo;
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Secret>> Get(string id)
    {
      Secret answer = _repo.GetForUser(id);
      if (answer != null)
      {
        return Ok(answer);
      }
      return BadRequest();
    }
    [HttpPost]
    public ActionResult<Secret> Post([FromBody] Secret value)
    {
      Secret answer = _repo.CreateMystery(value);
      return Created("/api/secret/" + answer.Id, answer);
    }
  }
}