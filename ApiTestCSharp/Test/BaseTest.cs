using RestAssured.Request.Builders;
using Xunit;

namespace ApiTestCSharp;

public class Tests
{
 
    [Fact]
    public void Setup()
    {
        RequestSpecBuilder requestSpecBuilder = new RequestSpecBuilder();
        requestSpecBuilder.WithBaseUri("https://reqres.in");
        requestSpecBuilder.WithBasePath("/api");
        requestSpecBuilder.WithContentType("application/json");
        requestSpecBuilder.Build();
    }

    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }
}