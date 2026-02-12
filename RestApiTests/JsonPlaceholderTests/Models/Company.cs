namespace JsonPlaceholderTests.Models;

public class Company
{
    public string Name { get; set; }
    public string CatchPhrase { get; set; }
    public string Bs { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Company other) return false;

        return Name == other.Name &&
               CatchPhrase == other.CatchPhrase &&
               Bs == other.Bs;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, CatchPhrase, Bs);
    }
}
