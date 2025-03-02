using FirmaXml.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace FirmaXml.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignController : ControllerBase
    {
        private readonly XmlSignerService _xmlSignerService;

        public SignController(XmlSignerService xmlSignerService)
        {
            _xmlSignerService = xmlSignerService;
        }

        [HttpPost("sign")]
        public IActionResult SignXml([FromBody] SignRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.XmlContent))
            {
                return BadRequest("Invalid request.");
            }

            var signedXml = _xmlSignerService.SignXml(request);
            return Ok(new { SignedXml = signedXml });
        }
    }
}