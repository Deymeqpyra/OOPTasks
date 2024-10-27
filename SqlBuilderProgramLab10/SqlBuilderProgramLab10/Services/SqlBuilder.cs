using System.Linq.Expressions;
using SqlBuilderProgramLab10.Entity;

namespace SqlBuilderProgramLab10.Services;

public abstract class SqlBuilder
{
    protected Query _query;

    public Query Build()
    {
        return _query;
    }
    public abstract SqlBuilder Select<T>();
    public abstract SqlBuilder OrderBy(string orderByColumnName);
    public abstract SqlBuilder OrderByDesc(string orderByColumnName);
    public abstract SqlBuilder Take(int count);
}