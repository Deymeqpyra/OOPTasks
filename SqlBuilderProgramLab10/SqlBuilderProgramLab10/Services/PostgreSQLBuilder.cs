using SqlBuilderProgramLab10.Entity;

namespace SqlBuilderProgramLab10.Services;

public class PostgreSQLBuilder : SqlBuilder
{
    public PostgreSQLBuilder()
    {
        _query = new Query("--------\nPostgres SQL Command\n--------");
    }
    public override SqlBuilder Select<T>()
    {
        _query["SELECT"] = "*";
        _query["FROM"] = typeof(T).Name;
        return this;
    }
    public override SqlBuilder OrderBy(string orderByColumnName)
    {
        _query["ORDER BY"] = $"{orderByColumnName} ASC";
        return this;
    }

    public override SqlBuilder OrderByDesc(string orderByColumnName)
    {
        _query["ORDER BY"] = $"{orderByColumnName} DESC";
        return this;
    }
    public override SqlBuilder Take(int count)
    {
        _query["LIMIT"] = $"{count}";
        return this;
    }
}