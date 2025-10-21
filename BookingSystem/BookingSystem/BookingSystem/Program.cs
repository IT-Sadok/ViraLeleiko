using BookingSystem.Models;
using BookingSystem.Repositories;
using BookingSystem.Services;

var repository = new HostRepository();
var hostService = new HostService(repository);

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("Вибери потрібний пункт у меню та натисни відповідну цифру:");
    Console.WriteLine(string.Join(Environment.NewLine, new[]
    {
        "1. Список хостів",
        "2. Показати хоста за ID",
        "3. Додавання нового хоста",
        "4. Редагування хоста",
        "5. Видалення хоста",
        "0. Вихід"
    }));

    Console.Write("\nВаш вибір: ");
    if (int.TryParse(Console.ReadLine(), out int menuId))
    {
        switch (menuId)
        {
            case 1:
                Console.WriteLine("\nСписок хостів:");
                var hosts = hostService.GetAllHosts();
                foreach (var h in hosts)
                {
                    Console.WriteLine($"{h.Id}. {h.Name}");
                }
                break;

            case 2:
                Console.Write("\nВведіть ID хоста: ");
                if (int.TryParse(Console.ReadLine(), out int hostId))
                {
                    var host = hostService.GetHostById(hostId);
                    if (host != null)
                    {
                        Console.WriteLine($"ID: {host.Id}, Ім'я: {host.Name}");
                        Console.WriteLine("Апартаменти:");
                        foreach (var apt in host.Apartments)
                            Console.WriteLine($"  - {apt.Id}: {apt.Name}");
                    }
                    else
                        Console.WriteLine("Хоста з таким ID не знайдено.");
                }
                break;

            case 3:
                Console.Write("\nВведіть ім'я нового хоста: ");
                string? name = Console.ReadLine();
                var newHost = new Host { Name = name ?? "Без назви" };
                hostService.AddHost(newHost);
                Console.WriteLine("Хоста додано!");
                break;

            case 4:
                Console.Write("\nВведіть ID хоста для редагування: ");
                if (int.TryParse(Console.ReadLine(), out int editId))
                {
                    var existingHost = hostService.GetHostById(editId);
                    if (existingHost != null)
                    {
                        Console.Write($"Введіть нове ім'я (поточне: {existingHost.Name}): ");
                        string? newName = Console.ReadLine();
                        existingHost.Name = string.IsNullOrWhiteSpace(newName) ? existingHost.Name : newName;

                        if (hostService.UpdateHost(existingHost))
                            Console.WriteLine("Хоста оновлено!");
                        else
                            Console.WriteLine("Не вдалося оновити хоста.");
                    }
                    else
                        Console.WriteLine("Хоста не знайдено.");
                }
                break;

            case 5:
                Console.Write("\nВведіть ID хоста для видалення: ");
                if (int.TryParse(Console.ReadLine(), out int deleteId))
                {
                    if (hostService.DeleteHost(deleteId))
                        Console.WriteLine("Хоста видалено.");
                    else
                        Console.WriteLine("Хоста не знайдено.");
                }
                break;

            case 0:
                Console.WriteLine("До побачення!");
                isRunning = false;
                break;

            default:
                Console.WriteLine("Невідомий пункт меню. Спробуйте ще раз.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Невірне введення. Введіть число від 0 до 5.");
    }
}


