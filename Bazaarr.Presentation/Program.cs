using Bazaarr.Data.DbContexts;
using Bazaarr.Data.IRepositories;
using Bazaarr.Data.Repositories;
using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.User;
using Bazaarr.Service.Interfaces;
using Bazaarr.Service.Services;

namespace Bazaarr.Presentation;

public class Program
{
    static async Task Main(string[] args)
    {

        IUserService userService = new UserService();
        UserForCreationDto user = new UserForCreationDto()
        {
            UserName = "Test",
            FirstName = "Test",
            LastName = "Test",
            Email = "Testttt",
            Password = "Test",
            PhoneNumber = "Test",
            Address = "Test",
        };

        //await userService.CreateAsync(user);




    }
}