using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BCrypt.Net;
using baalmy.Models;
using Dapper;

namespace baalmy.Repositories
{
  public class MysterySecretsRepository
  {
    public readonly IDbConnection _db;
    public MysterySecretsRepository(IDbConnection db)
    {
      _db = db;
    }
    public MysterySecret AddMysterySecret(MysterySecret val)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO mysterysecrets(mysteryId, secretId)
      VALUES(@MysteryId, @SecretId);
      SELECT LAST_INSERT_ID();
      ", val);
      val.Id = id;
      return val;
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
    public bool DeleteMystery(int id)
    {
      int success = _db.Execute(@"DELETE FROM mysteries WHERE id = @id", new { id });
      return success != 0;
    }
  }
}