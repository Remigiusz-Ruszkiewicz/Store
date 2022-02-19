using Microsoft.IdentityModel.Tokens;
using Store.Data;
using Store.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Services
{
    public class UsersService : IUsersService
    {
        private AuthDbContext dbContext;

        public UsersService(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<UserModel> AddAsync(string email, string password)
        {
            if (!dbContext.Users.Where(x => x.UserName == email).Any())
            {
                UserModel product1 = new UserModel();
                product1.Id = Guid.NewGuid();
                product1.UserName = email;
                product1.Password = password;
                dbContext.Users.Add(product1);
                bool isSuccesfull = dbContext.SaveChangesAsync().IsCompletedSuccessfully;
                if (isSuccesfull)
                {
                    return product1;
                }
                else return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserModel> LoginAsync(string email, string password)
        {
            var user = dbContext.Users.Where(x => x.UserName == email && x.Password == password);
            if (user.Count() == 1)
            {
                return user.Single();
            }
            else
            {
                return null;
            }
            
        }

        //private async Task<string> GenerateToken(string email)
        //{
        //    var user = await userManager.FindByNameAsync(email);
        //    var userRoles = await userManager.GetRolesAsync(user);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Id.ToString()),
        //    };
        //    foreach (var userRole in userRoles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, userRole));
        //    }
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
