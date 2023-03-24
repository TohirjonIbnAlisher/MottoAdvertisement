using MottoAdver.Domain;

namespace MottoAdver.Domain;
public class Addvertisements 
{
    public Guid Id { get; set; }
    public string AddvertiserFullName { get; set; }
    public long AddvertiserTelegramId { get; set; }
    public string AddvertiserTellNumber { get; set; }
    public decimal Price { get; set; }
    public Guid MotoId { get; set; }
    public Motos Moto { get; set; }
    public Guid AddressId { get; set; }
    public Addresses Address { get; set; }
}
