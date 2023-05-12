using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoNugetVirtualStore.Models;

namespace ApiVirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VistaComentariosController : ControllerBase
    {
        private IRepository repo;

        public VistaComentariosController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<VistaComentarios>>> GetVistaComentarios(int id)
        {
            return await this.repo.GetVistaComentarios(id);
        }
    }
}
