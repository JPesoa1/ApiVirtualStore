using ApiVirtualStore.Helpers;
using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProyectoNugetVirtualStore.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiVirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepository repo;
        private HelperOAuthToken helper;


        public AuthController(IRepository repo, HelperOAuthToken helper)
        {
            this.repo = repo;
            this.helper = helper;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            Usuario usuario =
                await this.repo.ExisteUsuario
                (model.UserName, model.Password);
            if (usuario == null)
            {
                return Unauthorized();
            }
            else
            {

                SigningCredentials credentials =
                    new SigningCredentials(this.helper.GetKeyToken()
                    , SecurityAlgorithms.HmacSha256);



                string jsonUser =
                    JsonConvert.SerializeObject(usuario);
                Claim[] informacion = new[]
                {
                    new Claim("UserData",jsonUser)
                };

                JwtSecurityToken token =
                    new JwtSecurityToken(
                        claims: informacion,
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        signingCredentials: credentials,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        notBefore: DateTime.UtcNow
                        );
                return Ok(new
                {
                    response =
                    new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }
    }
}
