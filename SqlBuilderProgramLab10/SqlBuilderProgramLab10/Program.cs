using SqlBuilderProgramLab10;
using SqlBuilderProgramLab10.Entity;
using SqlBuilderProgramLab10.Services;


SqlBuilder builder = null;

builder = new PostgreSQLBuilder();

var sqlDirector = new SqlDirector();

sqlDirector.SQLQueryWithOrderByDesc(builder);

sqlDirector.SQLQueryWithOrderByAsc(builder);

sqlDirector.SQLQueryWithTake(builder);


builder = new MSSQLBuilder();

sqlDirector.SQLQueryWithOrderByDesc(builder);

sqlDirector.SQLQueryWithOrderByAsc(builder);

sqlDirector.SQLQueryWithTake(builder);

