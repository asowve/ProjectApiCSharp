namespace JsonPlaceholderTests.Models;

public class Geo
{
    public string Lat { get; set; }
    public string Lng { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Geo other) return false;

        return Lat == other.Lat && Lng == other.Lng;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Lat, Lng);
    }
}
