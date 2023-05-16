using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoNugetVirtualStore.Models;

namespace ApiVirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        private IRepository repo;

        public JuegosController(IRepository repo)
        {
            this.repo = repo;
        }

     
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Juegos>>> GetJuegos()
        {
            return await this.repo.GetJuegos();
        }


        [HttpGet]
        [Route("[action]/{estado}")]
        public async Task<ActionResult<List<Juegos>>> GetJuegosEstados(string estado)
        {
            return await this.repo.GetJuegosEstados(estado);
        }

        [HttpGet]
        [Route("[action]/{idjuego}")]
        public async Task<ActionResult<Juegos>> FindJuego(int idjuego)
        {
            return await this.repo.GetJuego(idjuego);
        }


        [HttpGet]
        [Route("[action]/{posicion}/{precio}/{categoria}")]
        public async Task<ActionResult<ModelPaginarJuegos>>GetJuegosFiltros(int posicion,Decimal precio, string categoria)

        {
            return await this.repo.GetJuegosFiltros(posicion, precio, categoria);   

        }




        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<List<Juegos>>> GetJuegosCarrito(List<int> ids)
        {
            return await this.repo.GetJuegosCarritosAsync(ids);
        }
    }
}
