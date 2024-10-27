using SqlBuilderProgramLab10.Entity;

namespace SqlBuilderProgramLab10.Services;

public class SqlDirector
{
  public void SQLQueryWithOrderByDesc(SqlBuilder sqlBuilder)
  {
    var query = sqlBuilder.Select<User>()
     .OrderByDesc("RegestrationDate")
     .Take(10)
     .Build();
    
    query.CommandText();
    query.CommandParamets();
  } 
  public void SQLQueryWithOrderByAsc(SqlBuilder sqlBuilder)
  {
      var query = sqlBuilder.Select<User>()
          .OrderBy("RegestrationDate")
          .Build();
    
      query.CommandText();
      query.CommandParamets();
  } 
  public void SQLQueryWithTake(SqlBuilder sqlBuilder)
  {
      var query = sqlBuilder.Select<User>()
          .Take(10)
          .Build();
    
      query.CommandText();
      query.CommandParamets();
  } 
}