namespace DovhiiLab2;

public interface IDigitalWallet
{
    string PasswordAccount { get; }
    string LoginAccount { get; }
    ILoginProvider AuthProvider { get; }
    bool Deposit(decimal amount);
    bool Withdraw(decimal amount);
    decimal GetBalance();
    List<string> GetTransactionLog();
    void SetAuthProvider(ILoginProvider authProvider);
}