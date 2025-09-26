using BookingSystem.Models;

var hosts = new List<Host>
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

Console.WriteLine("Список хостів:");
foreach (var host in hosts)
{
    Console.WriteLine($"{host.Id}. {host.Name}");
}

Console.Write("\nВведіть ID хоста: ");
if (int.TryParse(Console.ReadLine(), out int hostId))
{
    var selectedHost = hosts.FirstOrDefault(h => h.Id == hostId);

    if (selectedHost != null)
    {
        Console.WriteLine($"\nАпартаменти {selectedHost.Name}:");
        foreach (var apt in selectedHost.Apartments)
        {
            Console.WriteLine($"- {apt.Id}: {apt.Name}");
        }
    }
    else
    {
        Console.WriteLine("Хоста з таким ID не знайдено.");
    }
}