namespace Domain.Admin;

public record AdminId(Guid Value)
{
    public static AdminId New() => new(Guid.NewGuid());
    public static AdminId Empty() => new(Guid.Empty);
    
    public override string  ToString() => Value.ToString();
}