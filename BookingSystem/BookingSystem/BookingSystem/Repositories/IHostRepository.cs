using BookingSystem.Models;

namespace BookingSystem.Repositories;

public interface IHostRepository
{
    IEnumerable<Host> GetAll();
    Host? GetById(int id);
    Host Add(Host host);
    bool Update(Host host);
    bool Delete(int id);
    void SaveChanges();
}