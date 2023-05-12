using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoNugetVirtualStore.Models;

namespace ApiVirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private IRepository repo;

        public CategoriasController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Categorias>>> GetCategorias()
        { 
            return await this.repo.GetCategorias();
        }
    }
}
