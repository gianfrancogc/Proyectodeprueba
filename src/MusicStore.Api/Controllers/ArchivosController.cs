using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Api.Archivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {

        public IActionResult RecibirArchivo(IFormFile formFile)
        {
            
            return Ok();
        }

    }
}
