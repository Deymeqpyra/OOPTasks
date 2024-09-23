namespace LabaratornaOOP1;

public class CoffeMachine : ICoffeMachine
{
    private double WaterAmount;
    private double CoffeAmount;
    private bool WaterIsHeated;

    public CoffeMachine(double WaterAmount, double CoffeAmount)
    {
        this.WaterAmount = WaterAmount;
        this.CoffeAmount = CoffeAmount; 
        this.WaterIsHeated = false;
    }

    private void HeatWater()
    {
            if (!WaterIsHeated)
            {
                WaterIsHeated = true;
                Thread.Sleep(2000);
                Console.WriteLine("Water is heated");
            } else 
                Console.WriteLine("Water is already heated");
    }

    private bool GrindBeans(double BeanAmount)
    {
        if (CoffeAmount >= BeanAmount)
        {
            CoffeAmount -= BeanAmount;
            Thread.Sleep(2000);
            Console.WriteLine("Bean was grinded");
            return true;
        }
        else
        {
            Console.WriteLine("Not enough beans");
            return false;
        }
    }

    public void MakeEspresso()
    {
        int requiredBeans = 20;
        if (WaterAmount <= 100)
        {
            Console.WriteLine("Not enough water to make espresso");
        }
        else
        {
            HeatWater();
            if (GrindBeans(requiredBeans))
            {
                WaterAmount -= 100;
                Thread.Sleep(2000);
                Console.WriteLine("Your espresso!"); 
            }
        }
        
    }
    public void MakeLatte()
    {
        int requiredBeans = 25;
        if (WaterAmount <= 200)
        {
            Console.WriteLine("Not enough water to make latte");
        }
        else
        {
            HeatWater();
            if (GrindBeans(requiredBeans))
            {
                
                WaterAmount -= 200;
                Thread.Sleep(2000);
                Console.WriteLine("Your latte!"); 
            }
        }
    }

    public void CoffeeMachineStatus()
    {
        Console.WriteLine($"Coffee machine status: \n Water amount: {WaterAmount} ml \n Coffee: {CoffeAmount} beans \n Water is heated: {WaterIsHeated}");
    }
    
}