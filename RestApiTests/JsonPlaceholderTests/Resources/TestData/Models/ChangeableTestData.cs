using JsonPlaceholderTests.Models;

namespace JsonPlaceholderTests.Resources.TestData.Models;

public class ChangeableTestData
{
    public int ExistingEndpointNumber { get; set; } = 0;
    public int NotExistingEndpointNumber { get; set; } = 0;
    public string BodyEmptyCondition { get; set; } = string.Empty;
    public int RequiredPostIdInPostNumber99 { get; set; } = 0;
    public int UserIdForPostInTestCase4 { get; set; } = 0;
    public int ExpectedIdInTestCase4 { get; set; } = 0;
    public int UserIdNumberForTestCase5 { get; set; } = 0;
    public List<User> Users { get; set; } = new List<User>();
}
