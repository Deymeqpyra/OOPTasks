using LabaratornaOOP1;

ICoffeMachine coffeMachine = new CoffeMachine(1000, 100);

int choice = 0;
Console.WriteLine("Welcome to the CoffeMachine!");

while (true)
{
    Console.WriteLine("Choose an option:  || [1] Make an Espresso || [2] Make a Latte || [3] Check status of CoffeeMachine || [4] Exit ");
    choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:  
            coffeMachine.MakeEspresso();
            break;
        case 2: 
            coffeMachine.MakeLatte();
            break;
        case 3:
            coffeMachine.CoffeeMachineStatus();
            break;
        case 4:
            Console.WriteLine("Goodbye!");
            return 0;
        default:
            Console.WriteLine("That's not a valid choice.");
            break;
    }
}