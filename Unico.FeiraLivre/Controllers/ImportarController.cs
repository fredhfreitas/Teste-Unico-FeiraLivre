using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Unico.FeiraLivre.Service.Features.FeiraFeatures.Commands;

namespace Unico.FeiraLivre.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Importar")]
    [ApiVersion("1.0")]    
    public class ImportarController : ControllerBase
    {        
        private readonly IConfiguration _configuration;
        public ILogger<ImportarController> _logger { get; }
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
       
        public ImportarController(IConfiguration configuration, ILogger<ImportarController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Importação dos dados contidos no arquivo csv que o path está configurado no appsetting.json
        /// </summary>
        /// <param name="yes">bool importar true/false</param>
        /// <returns></returns>
        [HttpPost("{sim}")]
        public async Task<IActionResult> ImportAsync(bool sim)
        {
            _logger.LogTrace("Inicio da importação do csv.");

            try
            {
                return Ok(await Mediator.Send(new ImportFeiraCommand { Import = sim, Path = _configuration["CsvFeira:Path"] }));
            }
            catch(Exception e)
            {
                _logger.LogError(string.Format("Erro ao realizar a importação de dados. {0}", e.Message));

                return StatusCode(500, e.Message);
            }            
        }
    }
}
