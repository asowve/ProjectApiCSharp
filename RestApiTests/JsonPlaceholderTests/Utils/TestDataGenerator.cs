using Bogus;

namespace JsonPlaceholderTests.Utils;

public static class TestDataGenerator
{
    private static readonly Faker _faker = new ();

    public static string GenerateWord()
    {
        return _faker.Lorem.Word();
    }
}
