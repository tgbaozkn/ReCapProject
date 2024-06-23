using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        carManager.Add(new Car {Id=2,BrandId=1,ColorId=1,DailyPrice="20",Description="Car ,Red", ModelYear="2023"});
        foreach(var result in carManager.GetCars())
        {
            Console.WriteLine(result.Description);
        }
        Console.WriteLine("Hello, World!");
    }
}