using ApiTestCSharp.Dtos;
using Microsoft.Extensions.Logging;

namespace ApiTestCSharp.Utils.service;

public class UserService
{
    private readonly BaseService _baseService = new("https://reqres.in");

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _baseService.GetAsync<User>($"/users/{id}");
    }

    public async Task<User?> CreateUserAsync(CreateUserRequest request)
    {
        return await _baseService.PostAsync<CreateUserRequest, User>("/users", request);
    }

    public async Task UpdateUserAsync(int id, CreateUserRequest request)
    {
        await _baseService.PutAsync<CreateUserRequest, User>($"/users/{id}", request);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _baseService.DeleteAsync($"/users/{id}");
    }

    public async Task<UserResponse?> Login(string endPoint, UserRequest userRequest)
    {
        return await _baseService.PostAsync<UserRequest, UserResponse>(endPoint,userRequest);
    }
}
