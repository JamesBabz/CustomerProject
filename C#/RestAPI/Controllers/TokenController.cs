﻿using BLL;
using BLL.Converters;
using DAL.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        IBLLFacade facade;
        private UserConverter userConv = new UserConverter();


        public TokenController(IBLLFacade facade)
        {
            this.facade = facade;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInput LoginInput)
        {
            var user = facade.UserService.GetAll().FirstOrDefault(u => u.Username == LoginInput.UserName);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!VerifyPasswordHash(LoginInput.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = GenerateToken(userConv.Convert(user))
            });
        }

        // This method verifies that the password entered by a user corresponds to the stored
        // password hash for this user. The method computes a Hash-based Message Authentication
        // Code (HMAC) using the SHA512 hash function. The inputs to the computation is the
        // password entered by the user and the stored password salt for this user. If the
        // computed hash value is identical to the stored password hash, the password entered
        // by the user is correct, and the method returns true.
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
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

        // This method generates and returns a JWT token for a user.
        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

            if (user.IsAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, // issuer - not needed (ValidateIssuer = false)
                    null, // audience - not needed (ValidateAudience = false)
                    claims.ToArray(),
                    DateTime.Now,               // notBefore
                    DateTime.Now.AddDays(1)));  // expires

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
