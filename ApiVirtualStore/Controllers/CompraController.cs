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
    public class CompraController : ControllerBase
    {
        private IRepository repo;

        public CompraController(IRepository repo)
        {
            this.repo = repo;
        }

      
        [HttpGet]
        [Route("[action]/{idcompra}")]
        public async Task<ActionResult<Compra>> FindCompra(int idcompra)
        {

            return await this.repo.FindCompra(idcompra);
           
        }


        [Authorize]
        [HttpPost]
        [Route("[action]")]
        
        public async Task<ActionResult> InsertarCompra(List<Juegos> juegos)
        {

            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");


            string jsonUsuario = claim.Value;

            Usuario usuarios = JsonConvert.DeserializeObject<Usuario>
                (jsonUsuario);
            await this.repo.InsertarCompra(juegos, usuarios.IdUsuario);
            return Ok();
               

        }


    }
}
