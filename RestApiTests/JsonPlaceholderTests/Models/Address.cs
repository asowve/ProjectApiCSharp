namespace JsonPlaceholderTests.Models;

public class Address
{
    public string Street { get; set; }
    public string Suite { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
    public Geo Geo { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Address other) return false;

        return Street == other.Street &&
               Suite == other.Suite &&
               City == other.City &&
               Zipcode == other.Zipcode &&
               Geo.Equals(other.Geo);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, Suite, City, Zipcode, Geo);
    }
}
