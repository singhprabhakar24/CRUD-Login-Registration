using API_FINAL.Response;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using API_FINAL.Models;

namespace API_FINAL.Authentication
{
    public interface ITokenService
    {

        string GenerateToken(IEnumerable<Claim> claims, string secret, int TokenExpiryInSeconds);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string secret);

        List<Claim> GetClaims(string token, string secret);

    }
} 
