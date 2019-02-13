
public class TestingMvcTestFixture<TStartup> : WebApplicationTestFixture<TStartup> where TStartup : class
{
    public TestingMvcTestFixture()
        : base("src/MvcAdo-in-DotNetCore-") { }
}