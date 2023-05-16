using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using SensorTemperature.API.Services;

namespace SensorTemperature.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _extensionContentTypeProvider;
        private readonly LocalMailService _mailService;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider, LocalMailService mailService)
        {
            _extensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
            _mailService = mailService ?? throw new System.ArgumentNullException(nameof(_mailService));
        }

        [HttpGet("{fileId}")]
        public ActionResult Getfile(string fileId)
        {
            var pathToFile = "temperaturefile.pdf";


            if(!System.IO.File.Exists(pathToFile))
            {
                return NotFound();  
            }

            if (! _extensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            return File(bytes, contentType, Path.GetFileName(pathToFile));

        }
    }
}
