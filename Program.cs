using System;

namespace Park{


    class Park
{
    // Field to store the list of cars
    private List<Car> cars;

    // Property for accessing the list of cars
    internal List<Car> Cars
    {
        get => cars;
        set => cars = value;
    }

    // Constructor to initialize the list of cars
    public Park()
    {
        cars = new List<Car>();
    }

    // Method to print all cars currently in the park
    public void PrintCarsInPark()
    {
        // Iterate through the list of cars and print each car's details
        foreach (var car in cars)
        {
            car.PrintCarDetails();
        }
    }

    // Method to add a car to the park
    public void AddCarToPark(Car car)
    {
        cars.Add(car);
    }

    // Method to remove a car from the park
    public void RemoveCarFromPark(Car car)
    {
        cars.Remove(car);
    }
}

    class Car
{
    // Properties for the Car class
    public string Plate { get; set; }
    public string Brand { get; set; }
    public string OwnerName { get; set; }
    public string TimeOfJoin { get; set; }
    
    // Constructor for the Car class
    public Car(string plate, string brand, string ownerName, string timeOfJoin)
    {
        this.Plate = plate;
        this.Brand = brand;
        this.OwnerName = ownerName;
        this.TimeOfJoin = timeOfJoin;
       
    }

    // You can add additional methods if needed
    public void PrintCarDetails()
    {
        Console.WriteLine($"Plate: {Plate}, Brand: {Brand}, Owner: {OwnerName}, Joined: {TimeOfJoin}");
    }
}
    

    class Program{

        static void Main(string[] args){
            
            Park park = new Park();
            bool activePark = true;

            while (activePark)
        {
            // Display the park menu
            Console.WriteLine("--------------");
            Console.WriteLine("-----PARK-----");
            Console.WriteLine("--------------");
            Console.WriteLine("- 1: Add Car -");
            Console.WriteLine("- 2: Remove Car -");
            Console.WriteLine("- 3: Check Cars -");
            Console.WriteLine("- 4: Exit -");
            Console.WriteLine("Please choose an option: ");

            // Read user input and parse it to an integer
            int inputKey;
            if (int.TryParse(Console.ReadLine(), out inputKey))
            {
                switch (inputKey)
                {
                    case 1:
                        // Add a car to the park
                        Console.WriteLine("Enter car plate: ");
                        string plate = Console.ReadLine();

                        Console.WriteLine("Enter car brand: ");
                        string brand = Console.ReadLine();

                        Console.WriteLine("Enter owner name: ");
                        string ownerName = Console.ReadLine();
                        
                        Console.WriteLine("Enter time of join (e.g., 2024-08-23 10:00): ");
                        string timeOfJoin = Console.ReadLine();

                        Car newCar = new Car(plate, brand, ownerName, timeOfJoin);
                        park.AddCarToPark(newCar);

                        Console.WriteLine("Car added successfully!");
                        break;

                    case 2:
                        // Remove a car from the park
                        Console.WriteLine("Enter the plate of the car to remove: ");
                        string plateToRemove = Console.ReadLine();
                        
                        Car carToRemove = park.Cars.Find(car => car.Plate == plateToRemove);
                        if (carToRemove != null)
                        {
                            park.RemoveCarFromPark(carToRemove);
                            Console.WriteLine("Car removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Car not found!");
                        }
                        break;

                    case 3:
                        // Check and display all cars in the park
                        Console.WriteLine("Cars currently in the park:");
                        park.PrintCarsInPark();
                        break;

                    case 4:
                        // Exit the program
                        Console.WriteLine("Exiting the park...");
                        activePark = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        
        }
    }
}