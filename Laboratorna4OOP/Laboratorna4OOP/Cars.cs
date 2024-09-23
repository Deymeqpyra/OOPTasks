namespace Laboratorna4OOP;

public class Cars(
    int id,
    string brand,
    decimal basePrice,
    double volume,
    double maxSpeed,
    string manufacturer,
    string color
    )
    : Vehicle(volume, maxSpeed, manufacturer, color)
{
    private int Id { get; set; } = id;
    public string Brand { get; private set; } = brand;
    public decimal BasePrice { get; private set; } = basePrice;
   

    public string GetInfo()
    {
        string info = $"Volume {base.Volume}l, " +
                      $"\n MaxSpeed : {base.MaxSpeed}km, " +
                      $"\n Manufacturer : {base.Manufacter}" +
                      $"\n Color : {base.Color} ";
        return info;
    }
}