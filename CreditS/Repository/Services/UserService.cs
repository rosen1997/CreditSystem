using AutoMapper;
using CreditS.Helpers;
using CreditS.Repository.Entities;
using CreditS.Repository.Models;
using CreditS.Repository.Services.Interfaces;
using CreditS.Repository.UnitOfWorkPattern;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CreditS.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, AppSettings appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.appSettings = appSettings;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user = unitOfWork.UserManager.GetByUsernameWithLoginInfo(username);
            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.LoginInfo.PasswordHash, user.LoginInfo.PasswordSalt))
                return null;

            var userModel = mapper.Map<UserModel>(user);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userModel.Id.ToString()),
                    new Claim(ClaimTypes.Role, userModel.Role.RoleDescription)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            userModel.Token = tokenHandler.WriteToken(token);

            return userModel;


        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public UserModel CreateUser(CreateUserModel createUserModel)
        {
            var userDb = unitOfWork.UserManager.GetByUsernameWithLoginInfo(createUserModel.Username);
            if (userDb != null)
            {
                //TODO: throw custom exception username taken
            }

            if (userDb.PhoneNumber.Equals(createUserModel.PhoneNumber))
            {
                //TODO: throw custom exception phone number is already registered
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(createUserModel.Password, out passwordHash, out passwordSalt);

            var newUser = mapper.Map<User>(createUserModel);
            int roleId = unitOfWork.RoleManager.GetAllAsNoTracking().First().Id;
            newUser.RoleId = roleId;

            LoginInfo loginInfo = new LoginInfo
            {
                Username = createUserModel.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                User = newUser
            };

            try
            {
                unitOfWork.LoginInfoManager.Create(loginInfo);
                unitOfWork.SaveChanges();
            }
            catch
            {
                throw;
            }

            return mapper.Map<UserModel>(loginInfo.User);
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = unitOfWork.UserManager.GetAllAsNoTracking();

            return mapper.Map<IEnumerable<UserModel>>(users);
        }
    }
}
