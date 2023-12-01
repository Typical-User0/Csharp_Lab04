class CarsCatalog
{
    Car[] cars;

    public CarsCatalog(Car[] obj)
    {
        cars = obj;
    }

    public Car this[int index] => cars[index];


    public IEnumerable<Car> ByYear(int year)
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].ProductionYear == year)
            {
                {
                    yield return cars[i];
                }
            }
        }
    }

    public IEnumerable<Car> Reverse()
    {
        foreach (Car car in cars.Reverse())
        {
            yield return car;
        }
    }

    public IEnumerable<Car> ByMaxSpeed(int speed)
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (Math.Abs(cars[i].MaxSpeed - speed) < 1e-4)
            {
                yield return cars[i];
            }
        }
    }
}

class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public double MaxSpeed { get; set; }

    public override string ToString() => $"{Name}, {ProductionYear}, {MaxSpeed}";
}


class Program
{
    static void Main()
    {
        Car cr1 = new Car();
        cr1.Name = "BMW";
        cr1.ProductionYear = 2014;
        cr1.MaxSpeed = 190;
        
        Car cr2 = new Car();
        cr2.Name = "Mercedes";
        cr2.ProductionYear = 2014;
        cr2.MaxSpeed = 195;
        
        Car cr3 = new Car();
        cr3.Name = "Audi";
        cr3.ProductionYear = 2023;
        cr3.MaxSpeed = 190;
        
        var list = new Car[] { cr1, cr2, cr3 };

        var catalog = new CarsCatalog(list);

        foreach (var car in catalog.ByYear(2014))
        {
           Console.WriteLine(car); 
        }
        
        foreach (var car in catalog.ByMaxSpeed(190))
        {
            Console.WriteLine(car); 
        }
        
        foreach (var car in catalog.Reverse())
        {
            Console.WriteLine(car); 
        }
    }
}