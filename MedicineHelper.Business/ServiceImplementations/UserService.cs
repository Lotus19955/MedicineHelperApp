using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.Business.ServicesImplementations;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleService _roleService;


    public UserService(IMapper mapper, 
        IConfiguration configuration, 
        IUnitOfWork unitOfWork, 
        IRoleService roleService)
    {
        _mapper = mapper;
        _configuration = configuration;
        _unitOfWork = unitOfWork;
        _roleService = roleService;
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        var user = await _unitOfWork.Users
            .FindBy(us => us.Email.Equals(email),
                us => us.Role)
            .AsNoTracking()
            .Select(user => _mapper.Map<UserDto>(user))
            .FirstOrDefaultAsync();
        if (user != null)
        {
            return user;
        }

        throw new ArgumentException(nameof(email));
    }

    public async Task<bool> IsUserExistsAsync(Guid userId)
    {
        return await _unitOfWork.Users.Get()
            .AnyAsync(user => user.Id.Equals(userId));
    }

    public async Task<bool> IsUserExistsAsync(string email)
    {
        return await _unitOfWork.Users.Get()
            .AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<bool> CheckUserPasswordAsync(string email, string password)
    {
        var dbPasswordHash = (await _unitOfWork.Users
                .Get().FirstOrDefaultAsync(user => user.Email.Equals(email)))
            ?.PasswordHash;

        return
            dbPasswordHash != null
            && CreateMd5(password).Equals(dbPasswordHash);
    }

    public async Task<bool> CheckUserPasswordAsync(Guid userId, string password)
    {
        var dbPasswordHash = (await _unitOfWork.Users
            .GetByIdAsync(userId))?.PasswordHash;

        return
            dbPasswordHash != null
            && CreateMd5(password).Equals(dbPasswordHash);
    }

    public async Task<int> RegisterUserAsync(UserDto dto)
    {
        var roleId = await _roleService.GetRoleIdForDefaultRoleAsync();
        
        dto.RoleId = roleId;
        var user = _mapper.Map<User>(dto);
        
        //can be refactor
        user.PasswordHash = CreateMd5(dto.Password);

        await _unitOfWork.Users.AddAsync(user);
        return await _unitOfWork.Commit();
    }

    private string CreateMd5(string password)
    {
        var passwordSalt = _configuration["UserSecrets:PasswordSalt"];

        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(password + passwordSalt);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}