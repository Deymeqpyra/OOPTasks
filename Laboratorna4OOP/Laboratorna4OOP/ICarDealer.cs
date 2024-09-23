namespace Laboratorna4OOP;

public interface ICarDealer
{
    Inventory CarInventory { get; }
    CurrentAccount CurrentAccountDealer { get; }
    string Name { get; }
    decimal Markup { get; }
    List<Cars> GetAllCars();
    decimal GetBalance();
    string GetInfoAboutCar(Cars car);
    bool SellVehicle(Cars vehicle, decimal finalPrice);
    bool BuyVehicle(Cars vehicle);
    bool ExchangeCar(ICarDealer dealer, Cars vehicleToGet, Cars vehicleToExchange);
}