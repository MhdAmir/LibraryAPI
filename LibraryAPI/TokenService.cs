using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace LibraryAPI
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username, string role)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            if (keyBytes.Length < 32)
            {
                keyBytes = PadOrExtendKey(keyBytes, 32);
            }

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(ClaimTypes.Role, role)
    };

            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private byte[] PadOrExtendKey(byte[] originalKey, int desiredLength)
        {
            byte[] paddedKey = new byte[desiredLength];

            Array.Copy(originalKey, paddedKey, Math.Min(originalKey.Length, desiredLength));

            for (int i = originalKey.Length; i < desiredLength; i++)
            {
                paddedKey[i] = (byte)(i % originalKey.Length);
            }

            return paddedKey;
        }
    
    }
}
