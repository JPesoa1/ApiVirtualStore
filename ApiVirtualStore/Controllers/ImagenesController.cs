using ApiVirtualStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoNugetVirtualStore.Models;

namespace ApiVirtualStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        private IRepository repo;

        public ImagenesController(IRepository repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]/{idjuego}")]
        public async Task<ActionResult<List<Imagenes>>> GetImagenes(int idjuego)
        {

            return await this.repo.GetImagenes(idjuego);
        }
    }
}
