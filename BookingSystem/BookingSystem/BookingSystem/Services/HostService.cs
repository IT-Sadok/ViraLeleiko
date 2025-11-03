using BookingSystem.Models;
using BookingSystem.Repositories;

namespace BookingSystem.Services;

public class HostService
{
    private readonly IHostRepository _repository;

    public HostService(IHostRepository repository)
    {
        _repository = repository; 
    }
    public IEnumerable<Host> GetAllHosts() => _repository.GetAll();

    public Host? GetHostById(int id) => _repository.GetById(id);

    public void AddHost(Host host) => _repository.Add(host);

    public bool UpdateHost(Host host) => _repository.Update(host);

    public bool DeleteHost(int id) => _repository.Delete(id);
    public void SaveChanges() => _repository.SaveChanges();
}