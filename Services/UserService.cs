using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FoodOrderingAPI;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;
    public UserService(IUserRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    User IUserService.Add(User user)
    {
        var addedUser = _repository.Add(user);
        return addedUser;
    }

    IEnumerable<User> IUserService.GetAll()
    {
        return _repository.GetAll();
    }
    User IUserService.GetById(int id)
    {
        return _repository.GetById(id);
    }
    User IUserService.Delete(int id)
    {
        return _repository.Delete(id);
    }
    User IUserService.Update(User user)
    {
        return _repository.Update(user);
    }
    
    LoginResponseViewModel IUserService.Login(LoginViewModel loginVM)
        {
            var response = _repository.Login(loginVM);

            if (response.IsSuccess)
            {
                response.Token = GenerateToken(response.User);
            }
            return response;
        }

        string GenerateToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration["AuthVariables:SecretKey"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.Role.ToString()),
                new Claim("MyClaim", user.Phone)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["AuthVariables:Issuer"],
                audience: _configuration["AuthVariables:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
}
