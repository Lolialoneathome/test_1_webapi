using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

[Route("/")]
public class HomeController
{

    private readonly IHttpContextAccessor _context;

    public HomeController(IHttpContextAccessor context)
    {
        _context = context;
    }

    private List<Person> people = new List<Person>
        {
            new Person { Login="u", Password="p", Role = "user" }
        };

    [HttpGet("token/{uname}/{pwd}")]
    public dynamic GetToken(string uname, string pwd)
    {
        var identity = GetIdentity(uname, pwd);
        if (identity == null)
            return "Invalid username/password";


        var handler = new JwtSecurityTokenHandler();

        var sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sec));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        
        var token = handler.CreateJwtSecurityToken(subject: identity,
                                                   signingCredentials: signingCredentials,
                                                   audience: "ExampleAudience",
                                                   issuer: "ExampleIssuer",
                                                   expires: DateTime.UtcNow.AddSeconds(42));
        return handler.WriteToken(token);
    }

    private ClaimsIdentity GetIdentity(string username, string password)
    {
        Person person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
        if (person != null)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        // если пользователя не найдено
        return null;
    }

}