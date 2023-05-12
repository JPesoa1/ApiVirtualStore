using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoNugetVirtualStore.Models;

namespace ApiVirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private IRepository repo;

        public ComentariosController(IRepository repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{idjuego}")]
        public async Task<ActionResult<List<Comentarios>>> GetComentarios(int idjuego)
        {
            return await this.repo.GetComentarios(idjuego);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertarComentarios(Comentarios comentarios)
        {
             await this.repo.InsertComentarios(comentarios.IdJuego, comentarios.IdUsuario, comentarios.Comentario, comentarios.FechaPost);
            return Ok();
        }

    }
}
