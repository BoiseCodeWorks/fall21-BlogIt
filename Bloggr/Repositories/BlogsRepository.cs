using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bloggr.Interfaces;
using Bloggr.Models;
using Dapper;

namespace Bloggr.Repositories
{
  public class BlogsRepository : DbContext, IRepository<Blog>
  {
    public BlogsRepository(IDbConnection db) : base(db)
    {
    }

    public Blog Create(Blog data)
    {
      string sql = @"
        INSERT INTO blogs(
          title, 
          body,
          published,
          imgUrl,
          creatorId
        )
        VALUES(
          @Title,
          @Body,
          @Published,
          @ImgUrl,
          @CreatorId
        );
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Blog Edit(int id, Blog data)
    {
      throw new System.NotImplementedException();
    }

    public List<Blog> Get()
    {
      string sql = "SELECT * FROM blogs";
      return _db.Query<Blog>(sql).ToList();
    }

    public Blog Get(int id)
    {
      string sql = "SELECT * FROM blogs WHERE id = @id";
      return _db.Query<Blog>(sql, new { id }).FirstOrDefault();
    }
  }
}