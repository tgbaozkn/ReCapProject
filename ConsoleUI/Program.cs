using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());
        foreach (var result in carManager.GetCars()) {
            Console.WriteLine(result.Description);
        };
        Console.WriteLine("Hello, World!");
    }
}