using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Unico.FeiraLivre.Domain.Entities;
using Unico.FeiraLivre.Persistence;

namespace Unico.FeiraLivre.Service.Features.FeiraFeatures.Commands
{
    public class CreateFeiraCommand : IRequest<int>
    {
        //public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string SetCens { get; set; }
        public string AreaP { get; set; }
        public string CodDist { get; set; }
        public string Distrito { get; set; }
        public string CodSubPref { get; set; }
        public string SubPref { get; set; }
        public string Regiao05 { get; set; }
        public string Regiao08 { get; set; }
        public string NomeFeira { get; set; }
        public string Registro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Referencia { get; set; }
        public class CreateFeiraCommandHandler : IRequestHandler<CreateFeiraCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateFeiraCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateFeiraCommand request, CancellationToken cancellationToken)
            {
                var feira = new Feira();
                feira.Longitude = request.Longitude;
                feira.Latitude = request.Latitude;
                feira.SetCens = request.SetCens;
                feira.AreaP = request.AreaP;
                feira.CodDist = request.CodDist;
                feira.Distrito = request.Distrito;
                feira.CodSubPref = request.CodSubPref;
                feira.SubPref = request.SubPref;
                feira.Regiao05 = request.Regiao05;
                feira.Regiao08 = request.Regiao08;
                feira.NomeFeira = request.NomeFeira;
                feira.Registro = request.Registro;
                feira.Logradouro = request.Logradouro;
                feira.Numero = request.Numero;
                feira.Bairro = request.Bairro;
                feira.Referencia = request.Referencia;

                _context.Feira.Add(feira);
                await _context.SaveChangesAsync();
                return feira.Id;
            }
        }
    }
}
