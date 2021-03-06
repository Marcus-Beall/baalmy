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
  public class MysteriesController : ControllerBase
  {
    private readonly MysteriesRepository _repo;

    public MysteriesController(MysteriesRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Mystery>> Get(string id)
    {
      return Ok(_repo.GetForUser(id));
    }
    [HttpPost]
    public ActionResult<Mystery> Post([FromBody] Mystery value)
    {
      Mystery answer = _repo.CreateMystery(value);
      return Ok(_repo.GetForUser(answer.UserId));
    }
    [HttpPut]
    public ActionResult<Mystery> Put([FromBody] Mystery val)
    {
      return Ok(_repo.ChangeMystery(val, val.Id));
    }
  }
}