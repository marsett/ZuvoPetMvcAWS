using Microsoft.AspNetCore.Mvc;
using ZuvoPetMvcAWS.Services;

namespace ZuvoPetMvcAWS.Controllers
{
    public class ImagenController : Controller
    {
        private readonly ServiceZuvoPet service;

        public ImagenController(ServiceZuvoPet service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetImagenAdoptante(string nombreImagen)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            if (string.IsNullOrEmpty(nombreImagen))
                return BadRequest();

            // Elimina cualquier query string del nombre de la imagen
            var nombreLimpio = nombreImagen.Split('?')[0];

            var url = service.GetPreSignedUrl(nombreLimpio);
            return Redirect(url);
        }

        [HttpGet]
        public IActionResult GetImagenRefugio(string nombreImagen)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            if (string.IsNullOrEmpty(nombreImagen))
                return BadRequest();

            // Elimina cualquier query string del nombre de la imagen
            var nombreLimpio = nombreImagen.Split('?')[0];

            var url = service.GetPreSignedUrl(nombreLimpio);
            return Redirect(url);
        }

    }
}