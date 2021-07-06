using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Unico.FeiraLivre.Service.Features.FeiraFeatures.Commands;
using Unico.FeiraLivre.Service.Features.FeiraFeatures.Queries;

namespace Unico.FeiraLivre.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Importar")]
    [ApiVersion("1.0")]    
    public class ImportarController : ControllerBase
    {        
        private readonly IConfiguration _configuration;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public ImportarController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Importação dos dados contidos no arquivo csv que o path está configurado no appsetting.json
        /// </summary>
        /// <param name="yes">bool importar true/false</param>
        /// <returns></returns>
        [HttpPost("{sim}")]
        public async Task<IActionResult> ImportAsync(bool sim)
        {            
            return Ok(await Mediator.Send(new ImportFeiraCommand { Import = sim, Path = _configuration["CsvFeira:Path"]}));
        }
    }
}
