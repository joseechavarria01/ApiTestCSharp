using ApiTestCSharp.Dtos;
using ApiTestCSharp.Utils.service;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ApiTestCSharp;

public class UserServiceTests
{
    private readonly UserService _userService = new();
    private ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddFilter(_ => true)
        .AddConsole());

    [Fact]
    public async Task LoginTest()
    {
        var logger = loggerFactory.CreateLogger<UserService>();
        
        logger.LogInformation("Se crea una instancia de usuario");
        UserRequest user = new UserRequest();
        user.email = "eve.holt@reqres.in";
        user.password = "cityslicka";
        
        logger.LogInformation("Se loguea el usuario");
        UserResponse? userResponse = await _userService.Login("/api/login", user);
        
        Assert.NotNull(userResponse);
        Console.WriteLine(userResponse.token);
        Assert.Equal("QpwL5tke4Pnpja7X4", userResponse.token,  StringComparer.OrdinalIgnoreCase);
    }
    
}
