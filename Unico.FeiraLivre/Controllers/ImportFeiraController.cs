using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unico.FeiraLivre.Service.Contract;

namespace Unico.FeiraLivre.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Importar")]
    [ApiVersion("1.0")]    
    public class ImportarController : ControllerBase
    {
        private readonly IImportFeiraService _importService;
        private readonly IConfiguration _configuration;
        public ImportarController(IImportFeiraService importService, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._importService = importService;
        }

        /// <summary>
        /// Importação dos dados contidos no arquivo csv que o path está configurado no appsetting.json
        /// </summary>
        /// <param name="yes">bool importar true/false</param>
        /// <returns></returns>
        [HttpPost("{sim}")]
        public async Task<IActionResult> ImportAsync(bool sim)
        {
            return Ok(await _importService.ImportFeiraAsync(sim, _configuration["CsvFeira:Path"]));
        }
    }
}
