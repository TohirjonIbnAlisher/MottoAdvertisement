namespace MottoAdver.Domain;

public class Motos
{
    public Guid Id { get; set; }
    public string MotoName { get; set; }
    public string Charge { get; set; }
    public string DistanceFullCharge { get; set; }
    public long MaxWeight { get; set; }
    public int Year { get; set; }
    public int MaxSpeed { get; set; }
}
