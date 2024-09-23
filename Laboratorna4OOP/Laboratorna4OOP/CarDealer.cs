namespace Laboratorna4OOP;

public class CarDealer(string name, Inventory carInventory, CurrentAccount currentAccount, decimal markUp) : ICarDealer
{
    private string _name { get; set; } = name;
    private Inventory _carInventory { get; set; } = carInventory;
    private CurrentAccount _accountCurrent { get; set; } = currentAccount;
    private decimal _markup { get; set; } = markUp;
    public string Name => _name;
    public decimal Markup => _markup;
    public Inventory CarInventory => _carInventory;
    public CurrentAccount CurrentAccountDealer => _accountCurrent;

    public string GetInfoAboutCar(Cars car)
    {
       return car.GetInfo();
    }

    public decimal GetBalance()
    {
        return CurrentAccountDealer.GetBalance();
    }
    public List<Cars> GetAllCars()
    { 
        return CarInventory.GetVehicles();
    }
    public bool SellVehicle(Cars vehicle, decimal finalPrice)
    {
        if (vehicle == null || !CarInventory.IsVehicleInStock(vehicle))
        {
            return false;
        }
        CarInventory.RemoveVehicle(vehicle);
        CurrentAccountDealer.AddToBalance(finalPrice);
        return true;
    }

    public bool BuyVehicle(Cars vehicle)
    {
        if (vehicle == null)
        {
            return false;
        }
        CarInventory.AddVehicle(vehicle);
        CurrentAccountDealer.DistractFromBalance(vehicle.BasePrice);
        return true;
    }

    public bool ExchangeCar(ICarDealer dealer, Cars vehicleToGet, Cars vehicleToExchange)
    {
        if (vehicleToGet == null || vehicleToExchange == null)
        {
            return false;
        }

        if (vehicleToGet.BasePrice > vehicleToExchange.BasePrice)
        {
            if (CurrentAccountDealer.GetBalance() < vehicleToGet.BasePrice)
            {
                return false;
            }
            decimal exchangeRate = vehicleToGet.BasePrice - vehicleToExchange.BasePrice;
            
            dealer.CurrentAccountDealer.AddToBalance(exchangeRate);
            CurrentAccountDealer.DistractFromBalance(exchangeRate);
            SwapCars(dealer, vehicleToGet, vehicleToExchange);
            return true;
        }
        else
        {
            SwapCars(dealer, vehicleToGet, vehicleToExchange);
            return true;
        }
    }

    private bool SwapCars(ICarDealer carDealer ,Cars vehicleToGet, Cars vehicleToExchange)
    {
        if (carDealer == null || vehicleToGet == null || vehicleToExchange == null)
        {
            return false;
        }
        carDealer.CarInventory.AddVehicle(vehicleToExchange);
        carDealer.CarInventory.RemoveVehicle(vehicleToGet);
        CarInventory.RemoveVehicle(vehicleToExchange);
        CarInventory.AddVehicle(vehicleToGet);
        return true;
    }
}