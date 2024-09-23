using Laboratorna4OOP;

public class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>();
        var user1 = new User("Anton", false);
        var user2 = new User("Admin", true);
        users.Add(user1);
        users.Add(user2);
        
        ICarDealer carDealer1 = new CarDealer("TopDealer", 
            new Inventory(), 
            new CurrentAccount(100000), 
            10);
        ICarDealer carDealer2 = new CarDealer("NeTopDealer", 
            new Inventory(), 
            new CurrentAccount(100000), 
            15);
        List<ICarDealer> dealers = new List<ICarDealer>();
        dealers.Add(carDealer1);
        dealers.Add(carDealer2);
        
        Cars car = new Cars(
            1, 
            "Audi", 
            1000, 
            1.2,
            200, 
            "VAG", 
            "Black");
        Cars car1 = new Cars(1, 
            "BMW", 
            1500, 
            1.5, 
            200, 
            "BMW", 
            "Black");
        Cars car2 = new Cars(
            1, 
            "KIA", 
            1500, 
            1.4, 
            200, 
            "Hyundai", 
            "Blue");
        Cars car3 = new Cars(
            1, 
            "Volkswagen", 
            2000, 
            1.6, 
            200, 
            "VAG", 
            "White");

        carDealer1.BuyVehicle(car);
        carDealer1.BuyVehicle(car1);
        carDealer2.BuyVehicle(car2);
        carDealer2.BuyVehicle(car3);

        bool MainMenu = true;
        User userThatLogined;
        ICarDealer carDealerThatChoosed = null;

        while (MainMenu)
        {
            Console.WriteLine("Please login by selecting a user from the list: ");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Name}"); 
            }

            Console.Write("Enter the number of the user to login: ");
            bool isValidChoice = int.TryParse(Console.ReadLine(), out int choice);

            if (isValidChoice && choice > 0 && choice <= users.Count)
            {
                userThatLogined = users[choice - 1];
                Console.WriteLine($"Logged in as: {userThatLogined.Name}");

                if (userThatLogined.IsAdmin)
                {
                    AdminMenu(users, dealers);
                }
                else
                {
                    UserMenu(dealers, ref carDealerThatChoosed, ref userThatLogined);
                }
                MainMenu = false;
            }
        }
    }

    static void UserMenu(List<ICarDealer> dealers, ref ICarDealer carDealerThatChoosed, ref User userThatLogined)
    {
        bool UserMenuActive = true;
        while (UserMenuActive)
        {
            Console.WriteLine("1. Choose car Dealer " +
                              "|| 2. Get All Vehicles " +
                              "|| 3. Get Info about car " +
                              "|| 4. Buy a car " +
                              "|| 5. Check is a car in other Car Dealer" +
                              "|| 6. Exchange cars");
            int choice = int.Parse(Console.ReadLine());

            switch ((UserChoice)choice)
            {
                case UserChoice.ChooseCarDealer:
                    for (int i = 0; i < dealers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dealers[i].Name}"); 
                    }
                    Console.Write("Enter the number of the car dealer to choose: ");
                    bool isValidChoiceOfCarDealer = int.TryParse(Console.ReadLine(), out choice);
                    if (isValidChoiceOfCarDealer && choice > 0 && choice <= dealers.Count)
                    {
                        carDealerThatChoosed = dealers[choice - 1];
                        Console.WriteLine($"CarDealerChoosed : {carDealerThatChoosed.Name}");
                    }
                    break;

                case UserChoice.GetAllVehicles:
                    if (carDealerThatChoosed == null)
                    {
                        Console.WriteLine("No car dealers chosen.");
                        break;
                    }
                       GetCarsList(carDealerThatChoosed);
                    break;

                case UserChoice.GetInfoAboutCar:
                    if (carDealerThatChoosed == null)
                    {
                        Console.WriteLine("No car dealers chosen.");
                        break;
                    }
                        var carsList = GetCarsList(carDealerThatChoosed);
                    Console.WriteLine("Choose a car: ");
                        int carChoice = int.Parse(Console.ReadLine());
                        Console.WriteLine(carDealerThatChoosed.GetInfoAboutCar(carsList[carChoice - 1]));
                    break;
                case UserChoice.BuyCar:
                    if (carDealerThatChoosed == null)
                    {
                        Console.WriteLine("No car dealers chosen.");
                        break;
                    }
                    var carsListToBuy = GetCarsList(carDealerThatChoosed);
                    if (!carsListToBuy.Any())
                    {
                        Console.WriteLine("No car left");
                        break;
                    }
                    
                    Console.WriteLine("Choose a car: ");
                    int carChoiceToBuy = int.Parse(Console.ReadLine());
                    carDealerThatChoosed.SellCarForCustomer(
                        userThatLogined, 
                        carsListToBuy[carChoiceToBuy - 1], 
                        carDealerThatChoosed.Markup
                        );
                    Console.WriteLine($"Thank you for buying  in {carDealerThatChoosed.Name}!");
                    Console.WriteLine("Your list of cars: ");
                    foreach (var userCars in userThatLogined.Inventory.GetVehicles())
                    {
                        Console.WriteLine(userCars.Brand);
                    }
                    break;
                case UserChoice.CheckIfItInStock: 
                    if (carDealerThatChoosed == null)
                    {
                        Console.WriteLine("No car dealers chosen.");
                        break;
                    }
                    Console.WriteLine("Choose a car dealer that will check");
                    for (int i = 0; i < dealers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dealers[i].Name}");
                    }
                    int dealerChoice = int.Parse(Console.ReadLine()) - 1;
                    if (dealerChoice >= 0 && dealerChoice < dealers.Count)
                    {
                        Console.WriteLine("Write a brand of car to find");
                        var carName = Console.ReadLine();
                        Console.WriteLine($"{dealers[dealerChoice].Name} - " +
                                          $"{carDealerThatChoosed.FindCarInOtherDealer(
                                              dealers[dealerChoice], 
                                              carName
                                              )
                                          }"); 
                    }
                    break;
                case UserChoice.ExchangeCar:
                    if (carDealerThatChoosed == null)
                    {
                        Console.WriteLine("No car dealers chosen.");
                        break;
                    }
                    Console.WriteLine("Choose a car dealer that will check");
                    for (int i = 0; i < dealers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dealers[i].Name}");
                    }
                    int dealerChoiceToExchange = int.Parse(Console.ReadLine()) - 1;
                    if (dealerChoiceToExchange >= 0 && dealerChoiceToExchange < dealers.Count)
                    {
                        var carsListToExtract = GetCarsList(carDealerThatChoosed);
                        Console.WriteLine("Choose a car to exchange: ");
                        var carToExtract = carsListToExtract[int.Parse(Console.ReadLine()) -1];
                        var carsListToGet = GetCarsList(dealers[dealerChoiceToExchange]);
                        Console.WriteLine("Choose a car to get: ");
                        var carToGet = carsListToGet[int.Parse(Console.ReadLine()) - 1];
                        carDealerThatChoosed.ExchangeCar(dealers[dealerChoiceToExchange],carToGet, carToExtract);
                    }
                    break;
            }
        }
    }

    private static List<Cars> GetCarsList(ICarDealer carDealerThatChoosed)
    {
        var carsList = carDealerThatChoosed.GetAllCars();
        for (int i = 0; i < carsList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {carsList[i].Brand}");
        }

        return carsList;
    }

    static void AdminMenu(List<User> users, List<ICarDealer> dealers)
    {
        bool AdminMenuActive = true;
        while (AdminMenuActive)
        {
            Console.WriteLine("1. Add Vehicle || " +
                              "2. Remove Vehicle || " +
                              "3. View All Users || " +
                              "4. Check Dealer Balance || " +
                              "5. Exit"
                              );
            int choice = int.Parse(Console.ReadLine());

            switch ((AdminChoice)choice)
            {
                case AdminChoice.AddVehicle:
                    Console.WriteLine("Choose a car dealer to add a vehicle to:");
                    for (int i = 0; i < dealers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dealers[i].Name}");
                    }
                    int dealerChoice = int.Parse(Console.ReadLine()) - 1;
                    if (dealerChoice >= 0 && dealerChoice < dealers.Count)
                    {
                        var selectedDealer = dealers[dealerChoice];
                        Console.WriteLine("Enter car details " +
                                          "(ID, Brand, Price, Engine Capacity, Horsepower, Manufacturer, Color):");
                        var newCar = new Cars(
                            int.Parse(Console.ReadLine()), 
                            Console.ReadLine(), 
                            decimal.Parse(Console.ReadLine()), 
                            double.Parse(Console.ReadLine()), 
                            double.Parse(Console.ReadLine()), 
                            Console.ReadLine(), 
                            Console.ReadLine());
                        selectedDealer.BuyVehicle(newCar);
                        Console.WriteLine("Vehicle added.");
                    }
                    break;

                case AdminChoice.RemoveVehicle:
                    Console.WriteLine("Choose a car dealer to remove a vehicle from:");
                    for (int i = 0; i < dealers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dealers[i].Name}");
                    }
                    dealerChoice = int.Parse(Console.ReadLine()) - 1;
                    if (dealerChoice >= 0 && dealerChoice < dealers.Count)
                    {
                        var selectedDealer = dealers[dealerChoice];
                        var cars = selectedDealer.GetAllCars();
                        for (int i = 0; i < cars.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {cars[i].Brand}");
                        }
                        Console.WriteLine("Enter the number of the car to remove:");
                        int carChoice = int.Parse(Console.ReadLine()) - 1;
                        if (carChoice >= 0 && carChoice < cars.Count)
                        {
                            selectedDealer.SellVehicle(cars[carChoice], cars[carChoice].BasePrice);
                            Console.WriteLine("Vehicle removed.");
                        }
                    }
                    break;

                case AdminChoice.ListOfUser: 
                    Console.WriteLine("List of users:");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.Name} (Admin: {user.IsAdmin})");
                    }
                    break;

                case AdminChoice.CheckBalance: 
                    Console.WriteLine("Choose a car dealer to check balance:");
                    for (int i = 0; i < dealers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {dealers[i].Name}");
                    }
                    dealerChoice = int.Parse(Console.ReadLine()) - 1;
                    if (dealerChoice >= 0 && dealerChoice < dealers.Count)
                    {
                        Console.WriteLine($"Dealer {dealers[dealerChoice].Name} has balance: {dealers[dealerChoice].GetBalance()}");
                    }
                    break;
                case AdminChoice.Exit:
                    AdminMenuActive = false;
                    break;
            }
        }
    }
}

public enum UserChoice
{
    ChooseCarDealer = 1,
    GetAllVehicles,
    GetInfoAboutCar,
    BuyCar,
    CheckIfItInStock,
    ExchangeCar
}
public enum AdminChoice
{
    AddVehicle = 1,
    RemoveVehicle,
    ListOfUser,
    CheckBalance,
    Exit
    
}
