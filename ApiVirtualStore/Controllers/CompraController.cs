using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoNugetVirtualStore.Models;

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

        [Authorize]
        [HttpGet]
        [Route("[action]/{idcompra}")]
        public async Task<ActionResult<Compra>> FindCompra(int idcompra)
        {

            return await this.repo.FindCompra(idcompra);
           
        }


        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Compra>> InsertarCompra(int idcompra)
        {

            return await this.repo.FindCompra(idcompra);

        }


    }
}
