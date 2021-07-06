using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyCsvParser;
using Unico.FeiraLivre.Domain.Common;
using Unico.FeiraLivre.Domain.Dto;
using Unico.FeiraLivre.Persistence;
using Unico.FeiraLivre.Service.Exceptions;

namespace Unico.FeiraLivre.Service.Features.FeiraFeatures.Commands
{
    public class ImportFeiraCommand : IRequest<Response<string>>
    {
        public bool Import { get; set; }
        public string Path { get; set; }        

        public static IEnumerable<FeiraCsv> ReadCsv(string absolutePath)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            var csvParser = new CsvParser<FeiraCsv>(csvParserOptions, new ImportFeiraCsvMapping());

            var records = csvParser.ReadFromFile(absolutePath, Encoding.UTF8);

            return records.Select(x => x.Result).ToList();
        }

        public class ImportFeiraCommandHandler : IRequestHandler<ImportFeiraCommand, Response<string>>
        {
            private readonly IApplicationDbContext _context;
            public ImportFeiraCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            
             public async Task<Response<string>> Handle(ImportFeiraCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request.Import)
                    {
                        IEnumerable<FeiraCsv> lista = ReadCsv(request.Path);
                       
                        foreach (var dado in lista)
                        {
                            if (dado != null)
                            {
                                Console.WriteLine("dado:" + dado.NOME_FEIRA);

                                var create = new CreateFeiraCommand
                                {
                                    Longitude = dado.LONG,
                                    Latitude = dado.LAT,
                                    SetCens = dado.SETCENS,
                                    AreaP = dado.AREAP,
                                    CodDist = dado.CODDIST,
                                    Distrito = dado.DISTRITO,
                                    CodSubPref = dado.CODSUBPREF,
                                    SubPref = dado.SUBPREFE,
                                    Regiao05 = dado.REGIAO5,
                                    Regiao08 = dado.REGIAO8,
                                    NomeFeira = dado.NOME_FEIRA,
                                    Registro = dado.REGISTRO,
                                    Logradouro = dado.LOGRADOURO,
                                    Numero = dado.NUMERO,
                                    Bairro = dado.BAIRRO,
                                    Referencia = dado.REFERENCIA
                                };
                            }
                        }
                    }
                    return new Response<string>($"Registros importados com sucesso");
                }
                catch (Exception ex)
                {
                    //Em caso de erro retorna apiExcetion e grava o log de erro                   
                    throw new ApiException("Erro ao importar os dados: " + ex.Message);
                }
            }
        }
    }
}
