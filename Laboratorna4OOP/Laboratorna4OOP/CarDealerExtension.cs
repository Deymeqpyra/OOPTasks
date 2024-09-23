namespace Laboratorna4OOP;

public static class CarDealerExtension
{
   public static bool SellCarForCustomer(
       this ICarDealer carDealer, 
       User userThatBuy, 
       Cars carThatSell, 
       decimal percentage)
    {
        if (carThatSell == null)
        {
            return false;   
        }
        decimal finalPrice = carThatSell.BasePrice + (carThatSell.BasePrice * (percentage / 100));
        carDealer.SellVehicle(carThatSell, finalPrice);
        userThatBuy.Inventory.AddVehicle(carThatSell);
        return true;
    }

    public static bool FindCarInOtherDealer(this ICarDealer carDealer, ICarDealer carDealerToAsk, string carToFind)
    {
        if (carDealerToAsk == null || carToFind == null)
        {
            return false;
        }
        return carDealerToAsk.CarInventory.FindByName(carToFind);
    }
}