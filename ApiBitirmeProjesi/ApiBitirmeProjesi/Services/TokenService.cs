using ApiBitirmeProjesi.Models.Authentication;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiBitirmeProjesi.Services;

public class TokenService
{
    // Kullanıcıya verdiğimiz tokenin geçerlilik süresi
    private const int ExpirationMinutes = 60;

    // Yönlendirilen kullanıcının bilgileriyle oluşturulan token 
    public string CreateToken(AppUser appUser)
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

        var token = CreateJwtToken(CreateClaims(appUser),
            CreateSigningCredentials(), expiration);

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(List<Claim> claims,SigningCredentials credentials, DateTime expiration)
    {
        return new JwtSecurityToken(
            "<https://localhost:5118/>",
            "<https://localhost:5118/>",
            claims,
            expires: expiration,
            signingCredentials: credentials
            );
    }


    // JWT'nin taşıdığı bilgileri temsil eden bölüm = Payload 
    private List<Claim> CreateClaims(AppUser appUser)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
            new(ClaimTypes.Name, appUser.UserName!),
            new(ClaimTypes.Email, appUser.Email!),
            new(ClaimTypes.Role, appUser.Role.ToString()),
        };
        return claims;
    }


    // Secret Key tanımladığımız bölüm
    private SigningCredentials CreateSigningCredentials()
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CfxuigpG1ka6VCzi/akulexlOCxK2vdUKwwbVr2KKo0="));

        return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    }
}
