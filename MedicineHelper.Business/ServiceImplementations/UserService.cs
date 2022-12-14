using AutoMapper;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Core.DataTransferObjects;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MediatR;
using MedicineHelper.Data.CQS.Queries;

namespace MedicineHelper.Business.ServicesImplementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public UserService(IMapper mapper, IConfiguration configuration,
            IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<bool> CheckUserPasswordAsync(string email, string password)
        {
            var dbPasswordHash = (await _unitOfWork.User.Get().FirstOrDefaultAsync(user => user.Email.Equals(email)))?.PasswordHash;

            return dbPasswordHash != null && CreateMd5($"{password}.{_configuration["Secret:PasswordSalt"]}").Equals(dbPasswordHash.ToUpper());
        }

        public async Task DeleteUserAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.User.FindBy(entity => entity.Id.Equals(id))
                    .Include(include => include.DoctorVisits)
                    .Include(include => include.DiseaseHistory)
                    .Include(include => include.Conclusion)
                    .Include(include => include.Vaccinations)
                    .Include(include => include.MedicineСheckup)
                    .Include(include => include.MedicinePrescription)
                    .Include(include => include.Fluorographies)
                    .Include(include => include.MedicineProcedure)
                    .FirstOrDefaultAsync();

                _unitOfWork.User.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw new ArgumentException("User for removing doesn't exist", nameof(id));
            }
        }
        //TODO need test
        public async Task DeleteUserAsync(string email)
        {
            try
            {
                var entity = await _unitOfWork.User.FindBy(entity => entity.Email.Equals(email))
                    .Include(include => include.DoctorVisits)
                    .Include(include => include.DiseaseHistory)
                    .Include(include => include.Conclusion)
                    .Include(include => include.Vaccinations)
                    .Include(include => include.MedicineСheckup)
                    .Include(include => include.MedicinePrescription)
                    .Include(include => include.Fluorographies)
                    .Include(include => include.MedicineProcedure)
                    .FirstOrDefaultAsync();

                _unitOfWork.User.Remove(entity);
                await _unitOfWork.Commit();
            }

            catch (Exception)
            {
                throw new ArgumentException("User for removing doesn't exist", nameof(email));
            }
        }

        public async Task<List<UserDto>> GetAllUserAsync()
        {
            try
            {
                var usersDto = await _unitOfWork.User.Get()
                    .Include(entity => entity.Role)
                    .Select(entities => _mapper.Map<UserDto>(entities)).ToListAsync();

                return usersDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDto?> GetUserByRefreshTokenAsync(Guid token)
        {
            var user = await _mediator.Send(new GetUserByRefreshTokenQuery() { RefreshToken = token });
            return user != null ?
            _mapper.Map<UserDto>(user) : null;
        }
        public UserDto? GetUserByEmailAsync(string email)
        {
            var user = _unitOfWork.User.FindBy(user => user.Email.Equals(email), user => user.Role).FirstOrDefault();
            return user != null ?
            _mapper.Map<UserDto>(user) : null;
        }

        public async Task<bool> IsUserExistAsync(string email)
        {
            var isExit = await _unitOfWork.User.FindBy(user => user.Email.Equals(email)).FirstOrDefaultAsync();

            return isExit != null;
        }

        public async Task<int> RegisterUser(UserDto userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            user.RegistrationDate = DateTime.Now;
            user.PasswordHash = CreateMd5($"{password}.{_configuration["Secret:PasswordSalt"]}");
            user.Email = user.Email.ToLower();

            await _unitOfWork.User.AddAsync(user);

            return await _unitOfWork.Commit();
        }

        public async Task<int> UpdateUserAsync(UserDto dto, Guid id)
        {
            try
            {
                var sourceDto = GetUserByEmailAsync(dto.Email);
                var patchList = new List<PatchModel>();

                if (dto.LastName != sourceDto.LastName)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.LastName),
                        PropertyValue = dto.LastName
                    });
                }
                if (dto.FirstName != sourceDto.FirstName)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.FirstName),
                        PropertyValue = dto.FirstName
                    });
                }
                if (dto.DateOfBirth != sourceDto.DateOfBirth)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.DateOfBirth),
                        PropertyValue = dto.DateOfBirth
                    });
                }
                if (dto.Avatar != sourceDto.Avatar)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Avatar),
                        PropertyValue = dto.Avatar
                    });
                }

                await _unitOfWork.User.PatchAsync(id, patchList);

                return await _unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> UpdateUserAsync(UserDto dto, string email)
        {
            try
            {
                var sourceDto = GetUserByEmailAsync(dto.Email);
                var patchList = new List<PatchModel>();

                if (dto.LastName != sourceDto.LastName)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.LastName),
                        PropertyValue = dto.LastName
                    });
                }
                if (dto.FirstName != sourceDto.FirstName)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.FirstName),
                        PropertyValue = dto.FirstName
                    });
                }
                if (dto.DateOfBirth != sourceDto.DateOfBirth)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.DateOfBirth),
                        PropertyValue = dto.DateOfBirth
                    });
                }
                if (dto.Email != sourceDto.Email)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Email),
                        PropertyValue = dto.Email
                    });
                }
                if (dto.Avatar != sourceDto.Avatar)
                {
                    patchList.Add(new PatchModel()
                    {
                        PropertyName = nameof(dto.Avatar),
                        PropertyValue = dto.Avatar
                    });
                }

                await _unitOfWork.User.PatchAsync(sourceDto.Id, patchList);

                return await _unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private string CreateMd5(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    public async Task DeleteAvatar(Guid id)
    {
        try
        {
            var entity = await _unitOfWork.User
                .FindBy(entity => entity.Id.Equals(id))
                .FirstOrDefaultAsync();

                entity.Avatar = null;
                await _unitOfWork.Commit();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
}
