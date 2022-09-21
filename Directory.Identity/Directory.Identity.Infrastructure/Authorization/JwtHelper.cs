﻿using Directory.Identity.Application.Commons.Interfaces;
using Directory.Identity.Application.Commons.Models.Authorization;
using Directory.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Directory.Identity.Infrastructure.Authorization;

public class JwtHelper : IJwtHelper
{
    private readonly TokenProviderOptions _options;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly SignInManager<User> _signInManager;

    public JwtHelper(TokenProviderOptions options, UserManager<User> um, RoleManager<Role> rm, SignInManager<User> sm)
    {
        _options = options;
        _userManager = um;
        _roleManager = rm;
        _signInManager = sm;
    }

    public async Task<string> GenerateJwtTokenAsync(User user, TimeSpan? expireIn = null)
    {
        List<string> claimChecker = new();
        var now = DateTime.UtcNow;
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
            new Claim(JwtRegisteredClaimNames.Sid, await _options.NonceGenerator()),
            new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim(ClaimKey.UserName, user.UserName),
            new Claim(ClaimKey.UserFullName, user.ToString()),
        };

        foreach (var roleName in await _userManager.GetRolesAsync(user))
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));

            var role = await _roleManager.FindByNameAsync(roleName);
            if (role is not null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);

                roleClaims = roleClaims.Where(q => !claimChecker.Contains(q.Value)).ToList();

                claims.AddRange(roleClaims);

                claimChecker.AddRange(roleClaims.Select(q => q.Value).ToList());
            }
        }

        var userClaims = await _userManager.GetClaimsAsync(user);
        if (userClaims is not null)
        {
            userClaims = userClaims.Where(q => !claimChecker.Contains(q.Value)).ToList();
            claims.AddRange(userClaims);
        }

        // Create the JWT and write it to a string
        var jwt = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: now,
            expires: now.Add(expireIn ?? _options.Expiration),
            signingCredentials: _options.SigningCredentials);
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        await _signInManager.SignInWithClaimsAsync(user, false, claims);

        return encodedJwt;
    }
}