using BookingSystem.Models;

namespace BookingSystem.Services;

public class ApartmentService
{
    private readonly Lock _locker = new Lock();
    
    public void IncreasePrice(Apartment apartment)
    {
        for (int i = 0; i < 100; i++)
        {
            var oldPrice = apartment.Price;
            apartment.Price = oldPrice + 10;
        }
    }

    public void IncreasePriceSafe(Apartment apartment)
    {
        for (int i = 0; i < 100; i++)
        {
            lock (_locker)
            {
                var oldPrice = apartment.Price;
                apartment.Price = oldPrice + 10;
            }
        }
    }
}