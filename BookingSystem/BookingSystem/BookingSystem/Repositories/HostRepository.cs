using BookingSystem.Repositories;
using BookingSystem.Models;
namespace BookingSystem.Repositories;

public class HostRepository: IHostRepository
{
    private readonly List<Host> _hosts = new List<Host>
    {
        new Host
        {
            Id = 1,
            Name = "Host Nuture",
            Apartments = new List<Apartment>
            {
                new Apartment { Id = 1, Name = "The Oasis" },
                new Apartment { Id = 2, Name = "The Park" },
                new Apartment { Id = 3, Name = "The Forest" }
            }
        },
        new Host
        {
            Id = 2,
            Name = "Host Urban",
            Apartments = new List<Apartment>
            {
                new Apartment { Id = 1, Name = "The Loft Life" },
                new Apartment { Id = 2, Name = "The Urban Utopia" }
            }
        }
    };

    private int nextId = 3;

    public IEnumerable<Host> GetAll() => _hosts;
    public Host? GetById(int id) => _hosts.FirstOrDefault(x => x.Id == id);

    public Host Add(Host host)
    {
        host.Id = nextId++;
        _hosts.Add(host);
        return host;
    }

    public bool Update(Host host)
    {
        var hostToUpdate = _hosts.FirstOrDefault(x => x.Id == host.Id);
        
        if (hostToUpdate == null)
            return false;
        
        hostToUpdate.Name = host.Name;
        hostToUpdate.Apartments = host.Apartments;
        return true;
    }

    public bool Delete(int id)
    {
        var hostToDelete = _hosts.FirstOrDefault(x => x.Id == id);
        if (hostToDelete == null)
            return false;
        _hosts.Remove(hostToDelete);
        return true;
    }


}