class Car
{
    public string name { get; set; }
    public int productionYear { get; set; }
    public double maxSpeed { get; set; }

    public override string ToString() => $"{name}, {productionYear}, {maxSpeed}";
}

class CarComparer : IComparer<Car>
{
    string option;

    public CarComparer(string option = "Name")
    {
        this.option = option;
    }

    public int Compare(Car car1, Car car2)
    {
        if (option == "Name")
        {
            return String.Compare(car1.name, car2.name, StringComparison.Ordinal);
        }
        if (option == "ProductionYear")
        {
            return car1.productionYear.CompareTo(car2.productionYear);
        }
        if (option == "MaxSpeed")
        {
            return car1.maxSpeed.CompareTo(car2.maxSpeed);
        }

        throw new ArgumentException("Invalid option");
    }
}

class Program
{
    static void Main()
    {
        Car cr1 = new Car();
        cr1.name = "BMW";
        cr1.productionYear = 2017;
        cr1.maxSpeed = 210;
        Car cr2 = new Car();
        cr2.name = "Mercedes";
        cr2.productionYear = 2014;
        cr2.maxSpeed = 195;
        Car cr3 = new Car();
        cr3.name = "Audi";
        cr3.productionYear = 2023;
        cr3.maxSpeed = 190;

        var list = new Car[] { cr1, cr2, cr3 };
        Array.Sort(list, new CarComparer());
        foreach (var car in list)
        {
            Console.WriteLine(car.ToString());
        }

        Array.Sort(list, new CarComparer("ProductionYear"));
        foreach (var car in list)
        {
            Console.WriteLine(car.ToString());
        }

        Array.Sort(list, new CarComparer("MaxSpeed"));
        foreach (var car in list)
        {
            Console.WriteLine(car.ToString());
        }
    }

   
}