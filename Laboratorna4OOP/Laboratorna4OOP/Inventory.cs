namespace Laboratorna4OOP;

public class Inventory
{
    private List<Cars> VehiclesStored {get; set;} = new List<Cars>();

    public bool AddVehicle(Cars vehicle)
    {
        if (vehicle == null)
        {
            return false;
        }
        VehiclesStored.Add(vehicle);
        return true;
    }

    public bool IsVehicleInStock(Cars vehicle)
    {
        if (VehiclesStored.Contains(vehicle) == false)
        {
            return false;
        }
        return true;
    }
    public bool FindByName(string vehicleName)
    {
        if (VehiclesStored.FirstOrDefault(x=>x.Brand.ToLower() == vehicleName.ToLower()) == null )
        {
            return false;
        }
        return true;
    }

    public bool RemoveVehicle(Cars vehicle)
    {
        if (vehicle == null)
        {
            return false;
        }
        VehiclesStored.Remove(vehicle);
        return true;    
    }

    public List<Cars> GetVehicles()
    {
        return VehiclesStored;
    }
}