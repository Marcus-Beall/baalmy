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
  class MysteriesController : ControllerBase
  {
    private readonly LibraryRepository _repo;

    public LibrarysController(LibraryRepository repo)
    {
      _repo = repo;
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Mystery>> Get(string id)
    {
      Mystery answer = _repo.GetForUser(id);
      if (answer != null)
      {
        return Ok(answer);
      }
      return BadRequest();
    }
    [HttpPost]
    public ActionResult<Mystery> Post([FromBody] Mystery value)
    {
      Mystery answer = _repo.CreateSecret(value);
      return Created("/api/mystery/" + answer.Id, answer);
    }
  }
}