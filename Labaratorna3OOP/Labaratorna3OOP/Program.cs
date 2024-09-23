using Labaratorna3OOP;
using System.Globalization;

Payment paymentProcessor = new Payment();

BankAccount bankAccount = new BankAccount();
WiseAccount wiseAccount = new WiseAccount();
PayonnerAccount payonnerAccount = new PayonnerAccount();
var rand = new Random();
decimal amount = rand.Next(1000, 9999);
Console.WriteLine($"How you want to proccess payment with this amount {amount}?");
Console.WriteLine("[1] Bank Account || [2] Wise Account || [3] Payonner Account || [4] Exit");
int choice = Convert.ToInt32(Console.ReadLine());
switch ((MenuNav)choice)
{
    case MenuNav.BankAccount:
        paymentProcessor.PaymentMethod(bankAccount, amount);
        break;
    case MenuNav.WiseAccount:
        paymentProcessor.PaymentMethod(wiseAccount, amount);
        break;
    case MenuNav.PayonnerAccount:
        paymentProcessor.PaymentMethod(payonnerAccount, amount);
        break;
    case MenuNav.Leave:
        Console.WriteLine("Bye");
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}

enum MenuNav
{
    BankAccount = 1,
    WiseAccount,
    PayonnerAccount,
    Leave
}