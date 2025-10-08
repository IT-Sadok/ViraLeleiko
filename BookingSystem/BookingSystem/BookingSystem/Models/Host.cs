namespace BookingSystem.Models;

public class Host
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Apartment> Apartments { get; set; }
}