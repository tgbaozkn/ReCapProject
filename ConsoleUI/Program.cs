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
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        ColorManager colorManager = new ColorManager(new EfColorDal());
        UserManager userManager = new UserManager(new EfUserDal());
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        RentalManager rentalManager = new RentalManager(new EfRentalDal());

        //foreach (var result in carManager.GetCarDetails())
        //{
        //    Console.WriteLine(result.BrandName);
        //    Console.WriteLine(result.ColorName);
        //    Console.WriteLine(result.Name);
        //}
        // CarTest(carManager);

        var result = rentalManager.Add(new Rental { RentDate = DateTime.Now, Id = 2, CarId = 2, CustomerId = 1 });

        if (!result.Succeeded)
        {
            Console.WriteLine(result.Message);
        }

    }
    #region TestKisim
    private static void CarTest(CarManager carManager)
    {
        var result = carManager.Add(new Car { Id = 3, BrandId = 1, ColorId = 1, DailyPrice = "20", Name = "araba", Description = "chery", ModelYear = "2024" });
        if (result.Succeeded)
        {
            var detailsofcars = carManager.GetCarDetails();
            foreach (var detailofcar in detailsofcars.Data)
            {
                Console.WriteLine(detailofcar.Name);
                Console.WriteLine(detailofcar.BrandName);
                Console.WriteLine(detailofcar.ColorName);
            }

        }
        Console.WriteLine(result.Message);
    }
    #endregion
}