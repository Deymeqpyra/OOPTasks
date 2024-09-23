namespace DovhiiLab2;

public interface ILoginProvider
{
    bool Validate(string login, string password);
}