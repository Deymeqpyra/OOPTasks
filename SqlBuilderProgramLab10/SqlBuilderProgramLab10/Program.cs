using SqlBuilderProgramLab10;
using SqlBuilderProgramLab10.Entity;
using SqlBuilderProgramLab10.Services;

SqlBuilder sqlBuilder = new PostgreSQLBuilder();

var queryPostgres = sqlBuilder.Select<User>()
    .OrderBy("RegestrationDate")
    .OrderByDesc("Name")
    .Take(10)
    .Build();

sqlBuilder = new MSSQLBuilder();
var queryMSSQL = sqlBuilder.Select<User>()
    .OrderBy("RegestrationDate")
    .OrderByDesc("Name")
    .Take(10)
    .Build();


queryPostgres.CommandText();
queryPostgres.CommandParamets();

queryMSSQL.CommandText();
queryMSSQL.CommandParamets();