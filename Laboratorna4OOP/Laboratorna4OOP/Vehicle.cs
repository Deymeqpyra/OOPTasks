namespace Laboratorna4OOP;

public class Vehicle(double volume,
    double maxSpeed,
    string manufacturer,
    string color)
{
    public double Volume { get; private set; } = volume;
    public double MaxSpeed { get; private set; } = maxSpeed;
    public string Manufacter { get; private set; } = manufacturer;
    public string Color { get; private set; } = color;
    
}