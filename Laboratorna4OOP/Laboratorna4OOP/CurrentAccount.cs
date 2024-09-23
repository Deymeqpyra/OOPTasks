namespace Laboratorna4OOP;

public class CurrentAccount(decimal balance)
{
    private decimal Balance {get; set;} = balance;

    public bool AddToBalance(decimal amount)
    {
        Balance += amount;
        return true;
    }

    public bool DistractFromBalance(decimal amount)
    {
        if (Balance < amount)
        {
            return false;
        }
        Balance -= amount;
        return true;
    }

    public decimal GetBalance()
    {
        return Balance;
    }
}