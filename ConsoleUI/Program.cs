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
        BrandManager brandManager = new BrandManager(new  EfBrandDal());
        ColorManager colorManager = new ColorManager(new EfColorDal());
       
        
        //foreach (var result in carManager.GetCarDetails())
        //{
        //    Console.WriteLine(result.BrandName);
        //    Console.WriteLine(result.ColorName);
        //    Console.WriteLine(result.Name);
        //}
        var carone = carManager.Get(1);
        carManager.Delete(carone);
        Console.WriteLine("Hello, World!");
    }
}