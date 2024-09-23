using System.Reflection;
using DovhiiLab2;

namespace DovhiiLab2
{
    class Program
    {
        enum MenuRegNav{
            Register = 1,
            Login,
            Exit
        }

        enum MenuAuthNav
        {
            Gmail = 1, 
            Privat24,
        }
        enum MainMenuNav
        {
            CheckBalance = 1,
            Deposit,
            WithDraw,
            ViewLog,
            Exit
        }
        static void Main(string[] args)
        {
            
            List<IDigitalWallet> wallets = new List<IDigitalWallet>();
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Choose an option: || [1] Register || [2] Login || [q] Exit ");
                int choice = int.Parse(Console.ReadLine());
                IDigitalWallet wallet;
                switch ((MenuRegNav)choice)
                {
                    case MenuRegNav.Register:
                        Console.WriteLine("Choose an authentication provider:");
                        Console.WriteLine("1. Gmail");
                        Console.WriteLine("2. Privat24");
                        choice = int.Parse(Console.ReadLine());
                        string password;
                        switch ((MenuAuthNav)choice)
                        {
                            case MenuAuthNav.Gmail:
                                Console.Write("Enter your email: ");
                                string email = Console.ReadLine();
                                Console.Write("Enter your password: ");
                                password = Console.ReadLine();
                                wallet = new DigitalWallet(email, password);
                                wallet.SetAuthProvider(new GmailAuthProvider(email, password));
                                wallets.Add(wallet);
                                MainMenu(wallet);
                                break;
                            case MenuAuthNav.Privat24:
                                Console.Write("Enter your phone number: ");
                                string phone = Console.ReadLine();
                                Console.Write("Enter your password: ");
                                password = Console.ReadLine();
                                wallet = new DigitalWallet(phone, password);
                                wallet.SetAuthProvider(new Privat24AuthProvider(phone, password));
                                wallets.Add(wallet);
                                MainMenu(wallet);
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                return;
                        }

                        break;
                    case MenuRegNav.Login:
                        Console.Write("Enter your login: ");
                        string login = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string password1 = Console.ReadLine();
                        IDigitalWallet userToFind = wallets
                            .First(x => x.LoginAccount == login);
                        if (userToFind == null)
                        {
                            throw new UnauthorizedAccessException("Invalid credentials");
                        }

                        if (userToFind.AuthProvider.Validate(login, password1))
                        {
                            Console.WriteLine("Hello");
                            MainMenu(userToFind);
                            break;
                        }
                        else
                        {
                            throw new UnauthorizedAccessException("Invalid credentials");
                            break;
                        }
                    case MenuRegNav.Exit:
                        return;
                }
            }
        }

        static void MainMenu(IDigitalWallet wallet)
        {
            bool regMenu = true;
            ;
            while (regMenu)
            {
                Console.WriteLine(
                    "Choose an option:  || [1] Check balance || [2] Deposit || [3] Withdraw || [4] View Transactions || [q] Exit ");
                int option = Int32.Parse(Console.ReadLine());
                switch ((MainMenuNav)option)
                {
                    case MainMenuNav.CheckBalance:
                        Console.WriteLine($"Balance: {wallet.GetBalance()}$");
                        break;
                    case MainMenuNav.Deposit:
                        Console.Write("Enter amount to deposit: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        wallet.Deposit(depositAmount);
                        break;
                    case MainMenuNav.WithDraw:
                        Console.Write("Enter amount to withdraw: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        wallet.Withdraw(withdrawAmount);
                        break;
                    case MainMenuNav.ViewLog:
                        var transactions = wallet.GetTransactionLog();
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine(transaction);
                        }

                        break;
                    case MainMenuNav.Exit:
                        regMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}