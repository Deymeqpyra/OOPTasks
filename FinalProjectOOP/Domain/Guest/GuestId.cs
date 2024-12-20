namespace Domain.Guest;

public record GuestId(Guid Value)
{
    public static GuestId New() => new(Guid.NewGuid());
    public static GuestId Empty() => new(Guid.Empty);
    
    public override string ToString() => Value.ToString();
}