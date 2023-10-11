using AutoMapper;
using Bazaarr.Data.IRepositories;
using Bazaarr.Data.Repositories;
using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.User;
using Bazaarr.Service.Exceptions;
using Bazaarr.Service.Interfaces;
using Bazaarr.Service.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Bazaarr.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper = MappingProfile.Initialize();
    private readonly IRepository<Domain.Models.User> userRepository = new Repository<Domain.Models.User>();

    public async Task<DTOs.User.UserForResultDto> CreateAsync(DTOs.User.UserForCreationDto dto)
    {
        var user = this.userRepository.SelectAll().
            FirstOrDefault(u => u.Email.ToLower() == dto.Email.ToLower());
        if (user is not null)
            throw new CustomException(400, "User is already exist");

        var mappedUser = this.mapper.Map<Domain.Models.User>(dto);

        var insertedUser = await userRepository.InsertAsync(mappedUser);    

        var result = this.mapper.Map<DTOs.User.UserForResultDto>(insertedUser);

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        await this.userRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<DTOs.User.UserForResultDto>> RetrieveAllAsync()
    {
        var users = await this.userRepository.SelectAll()
            .Include(u => u.Carts)
            .ToListAsync();

        var mappedUsers = this.mapper.Map<IEnumerable<DTOs.User.UserForResultDto>>(users);

        return mappedUsers;
    }

    public async Task<DTOs.User.UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        var mappedUser = this.mapper.Map<DTOs.User.UserForResultDto>(user);

        return mappedUser;
    }

    public async Task<DTOs.User.UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var user = await this.userRepository.SelectByIdAsync(dto.Id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        var mappedUser = this.mapper.Map<Domain.Models.User>(dto);
        mappedUser.UpdatedAt = DateTime.UtcNow;
        await this.userRepository.UpdateAsync(mappedUser);

        return this.mapper.Map<DTOs.User.UserForResultDto>(mappedUser);
    }
}
