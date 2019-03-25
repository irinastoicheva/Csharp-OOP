namespace P03.Ferrari
{
    public interface ICar
    {
        string Model { get; set; }
        string Driver { get; set; }

        string Brakes();
        string Gas();
    }
}
