using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BCrypt.Net;
using baalmy.Models;
using Dapper;

namespace baalmy.Repositories
{
  public class MysteriesRepository
  {
    private readonly IDbConnection _db;
    public MysteriesRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Mystery> GetForUser(string id)
    {
      return _db.Query<Mystery>($"SELECT * FROM mysteries WHERE userId = @id", new { id });
    }
    public Mystery CreateMystery(Mystery val)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO mysteries(name, description, userId) 
      VALUES(@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();
      ", val);
      val.Id = id;
      return val;
    }
    public Mystery ChangeMystery(Mystery val, int id)
    {
      try
      {
        return _db.QueryFirstOrDefault<Mystery>($@"
UPDATE mysteries SET
  Name = @Name,
  Description = @Description
  WHERE Id = @Id;
SELECT * FROM mysteries WHERE id = @Id;", val);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public bool DeleteMystery(int id)
    {
      int success = _db.Execute(@"DELETE FROM mysteries WHERE id = @id", new { id });
      return success != 0;
    }
  }
}