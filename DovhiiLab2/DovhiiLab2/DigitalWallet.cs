using System.Security.Cryptography;
using System.Text;
namespace DovhiiLab2;

public class DigitalWallet : IDigitalWallet
{
    private decimal _balanceAccount;
    private readonly string _loginAccount;
    private readonly string _passwordAccount; 
    private List<string> _transactionLog = new List<string>();
    private ILoginProvider _authProvider;
    private readonly string _unhashedPassword;
    public string LoginAccount => _loginAccount;
    public string PasswordAccount => _passwordAccount;
    public ILoginProvider AuthProvider => _authProvider;
    public DigitalWallet(string login, string password)
    {
        _loginAccount = login;
        _unhashedPassword = password;
        _passwordAccount = HashPassword(password);
        _transactionLog = new List<string>();
    }
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
    public bool Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _authProvider.Validate(LoginAccount, _unhashedPassword);
            _balanceAccount += amount;
            _transactionLog.Add($"Money was added to {_loginAccount}: new Balance ${_balanceAccount}");
            Console.WriteLine($"Money was added to {_loginAccount}: new Balance ${_balanceAccount}");
            return true;
        }
            _transactionLog.Add("Deposit failed");
            Console.WriteLine("Wrong input");
            return false;
    }

    public bool Withdraw(decimal amount)
    {
        _authProvider.Validate(LoginAccount, _unhashedPassword);
        if (_balanceAccount >= amount)
        {
            _balanceAccount -= amount;
            _transactionLog.Add($"Money was withdrawed from {_loginAccount}: new Balance ${_balanceAccount}");
            Console.WriteLine($"Money was withdrawed from {_loginAccount}: new Balance ${_balanceAccount}");
            return true;
        }
            _transactionLog.Add($"Failed attempt to withdraw from {_loginAccount}.");
            Console.WriteLine("Not enough money to withdraw");
            return false; 
    }
    public decimal GetBalance()
    {
        _authProvider.Validate(LoginAccount, _unhashedPassword);
        _transactionLog.Add($"Balance was retrieved from {_loginAccount}.");
        return _balanceAccount;
    }

    public List<string> GetTransactionLog()
    {
        _authProvider.Validate(LoginAccount, _unhashedPassword);
        return _transactionLog;
    }
    public void SetAuthProvider(ILoginProvider authProvider)
    {
        _authProvider = authProvider;
    }
}