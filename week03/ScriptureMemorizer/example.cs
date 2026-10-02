class Car
{
    private double _fuelCapacity;
    private double _fuelLoad;
    public Car(double capacity)
    {
        _fuelCapacity = capacity;
    }
    public double FuelCapacity => _fuelCapacity;

    public double FuelLoad
    {
        get => _fuelLoad;
        set
        {
            if (value >= 0 && value <= _fuelCapacity)
                _fuelLoad = value;
            else
                Console.WriteLine("Cantidad inválida");
        }
    }
}
// Use
class Program
{
    static void Main()
    {
        Car auto = new Car(50);
        auto.FuelLoad = 30; // Usa el setter
        Console.WriteLine(auto.FuelLoad); // Usa el getter: 30
        auto.FuelLoad = 100; // Imprime: Cantidad inválida
    }
}
