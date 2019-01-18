using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using baalmy.Models;
using Dapper;

namespace baalmy.Repositories
{
  public class SecretsRepository
  {
    public readonly IDbConnection _db;
    public SecretsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Secret> GetForUser(string id)
    {
      return _db.Query<Secret>($"SELECT * FROM secrets WHERE userId = @id", new { id });
    }
    public Secret CreateSecret(Secret val)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO secrets(name, description, img, userId)
      VALUES(@Name, @Description, @Img, @UserId);
      SELECT LAST_INSERT_ID();
      ", val);
      val.Id = id;
      return val;
    }
    public Secret ChangeSecret(int id, Secret val)
    {
      try
      {
        return _db.QueryFirstOrDefault<Secret>($@"
UPDATE secrets SET
name = @Name,
description = @Description,
img = @Img
WHERE id = @Id;
SELECT * FROM secrets WHERE id = @Id;
", val);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public bool DeleteSecret(int id)
    {
      int success = _db.Execute(@"DELETE FROM secrets WHERE id = @id", new { id });
      return success != 0;
    }
  }
}