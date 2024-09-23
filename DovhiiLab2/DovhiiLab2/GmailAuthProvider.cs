using System.Net.Mail;

namespace DovhiiLab2;

public class GmailAuthProvider : ILoginProvider
{
    private string _gmail;
    private string _password;

    public GmailAuthProvider(string gmail, string password)
    {
        if (!ValidateGmail(gmail))
        {
            return;
        }
        _gmail = gmail;
        _password = password;
    }

    public static bool ValidateGmail(string input)
    {
        try
        {
            MailAddress m = new MailAddress(input);

            return true;
        }
        catch
        {
            return false;
        }
        
    }
    public bool Validate(string login, string password)
    {
        if (_gmail == login && _password == password)
        {
            return true;
        }
        throw new UnauthorizedAccessException("Invalid credentials");
    }
}