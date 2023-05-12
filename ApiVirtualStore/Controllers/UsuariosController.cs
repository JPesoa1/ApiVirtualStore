using ApiVirtualStore.Helpers;
using ApiVirtualStore.Models;
using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoNugetVirtualStore.Models;
using System.Security.Claims;

namespace ApiVirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IRepository repo;

        public UsuariosController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> RegisterUsario(UsuarioAux usuario)
        {
          
            await this.repo.RegisterUser(usuario.Nombreusuario,usuario.Password,usuario.Email);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Usuario>> DetailsUsuario()
        {
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");


            string jsonUsuario = claim.Value;

            Usuario usuarios = JsonConvert.DeserializeObject<Usuario>
                (jsonUsuario);

            return usuarios;
        }


        [HttpPost]
        [Route("[action]/{imagen}")]
        public async Task<ActionResult<Usuario>> ModificarUsuarioImagen(string imagen)
        {
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");


            string jsonUsuario = claim.Value;

            Usuario usuarios = JsonConvert.DeserializeObject<Usuario>
                (jsonUsuario);
            await this.repo.ModificarUsuarioImagen(usuarios.IdUsuario, imagen);
            return Ok();
        }
    }
}
