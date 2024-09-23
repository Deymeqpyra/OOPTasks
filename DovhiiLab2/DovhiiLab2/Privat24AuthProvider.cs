using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;

namespace DovhiiLab2;

public class Privat24AuthProvider : ILoginProvider
{
    private string _phoneNumber;
    private string _password;

    public Privat24AuthProvider(string phoneNumber, string password)
    {
        if (IsValidPhoneNumber(phoneNumber))
        {
            Console.WriteLine("Invalid phone number");
            return;
        }
        _phoneNumber = phoneNumber;
        _password = password;
    }
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        string pattern = @"^(\+?\d{1,2}\s?)?(\(?\d{3}\)?[\s.-]?)?\d{3}[\s.-]?\d{4}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }

    public bool Validate(string login, string password)
    {
        if (_phoneNumber == login && _password == password)
        {
            return true;
        }
        throw new UnauthorizedAccessException("Invalid credentials");
    }
}