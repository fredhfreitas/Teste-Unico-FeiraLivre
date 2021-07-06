using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Unico.FeiraLivre.Domain.Entities;
using Unico.FeiraLivre.Persistence;
using Unico.FeiraLivre.Domain.Common;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Unico.FeiraLivre.Service.Exceptions;
using Unico.FeiraLivre.Service.Contract;
using Unico.FeiraLivre.Service.Features.FeiraFeatures.Commands;

namespace Unico.FeiraLivre.Service.Implementation
{
    public class ImportFeiraService : IImportFeiraService
    {
        public ILogger<ImportFeiraService> _logger { get; }

        private readonly IMediator _mediator;
        public ImportFeiraService(IMediator mediator, IOptions<FeiraCsv> mailSettings, ILogger<ImportFeiraService> logger)
        {
            this._mediator = mediator;
            _logger = logger;
        }

        private List<FeiraCsv> ReadCsv(string filename)
        {
            List<FeiraCsv> lines = new List<FeiraCsv>();

            try
            {
                using (var fs = new StreamReader(filename))
                {
                    lines = new CsvHelper.CsvReader((CsvHelper.IParser)fs).GetRecords<FeiraCsv>().ToList();
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException($"Erro ao ler o CSV. " + ex.Message);
            }

            return lines;
        }
        /// <summary>
        /// Importa os dados de forma async
        /// </summary>
        /// <param name="import">bool importar true/false</param>
        /// <param name="path">string path do arquivo csv passado pela controller</param>
        /// <returns></returns>
        public async Task<Response<string>>  ImportFeiraAsync(bool import, string path)
        {
            try
            {
                if (import)
                {
                    List<FeiraCsv> lista = ReadCsv(path);
                    
                    foreach (var dado in lista)
                    {                      
                        await _mediator.Publish(new CreateFeiraCommand {                            
                            Longitude = dado.LONG,
                            Latitude = dado.LAT,
                            SetCens = dado.SETCNS,
                            AreaP = dado.AREAP,
                            CodDist = dado.CODDIST,
                            Distrito = dado.DISTRITO,
                            CodSubPref = dado.CODSUBPREF,
                            SubPref = dado.SUBPREF,
                            Regiao05 = dado.REGIAO05,
                            Regiao08 = dado.REGIAO08,
                            NomeFeira = dado.NOMEFEIRA,
                            Registro = dado.REGISTRO,
                            Logradouro = dado.LOGRADOURO,
                            Numero = dado.NUMERO,
                            Bairro = dado.BAIRRO,
                            Referencia = dado.REFERENCIA
                        });
                    }
                }
                return new Response<string>($"Registros importados com sucesso");
            }
            catch (System.Exception ex)
            {
                //Em caso de erro retorna apiExcetion e grava o log de erro
                _logger.LogError(ex.Message, ex);
                throw new ApiException($"Erro ao importar registro. " + ex.Message);
            }            
            
        }

    }
}
