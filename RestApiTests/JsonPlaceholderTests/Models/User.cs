namespace JsonPlaceholderTests.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    public Company Company { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not User other) return false;

        return Id == other.Id &&
               Name == other.Name &&
               Username == other.Username &&
               Email == other.Email &&
               Phone == other.Phone &&
               Website == other.Website &&
               Address.Equals(other.Address) &&
               Company.Equals(other.Company);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Username, Email, Phone, Website, Address, Company);
    }
}
