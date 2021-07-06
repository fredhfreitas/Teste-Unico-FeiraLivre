using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unico.FeiraLivre.Domain.Entities;
using Unico.FeiraLivre.Persistence;

namespace Unico.FeiraLivre.Service.Features.FeiraFeatures.Queries
{
    public class GetFeiraByDistritoQuery : IRequest<Feira>
    {
        public string Distrito { get; set; }
        public class GetFeiraByDistritoQueryHandler : IRequestHandler<GetFeiraByDistritoQuery, Feira>
        {
            private readonly IApplicationDbContext _context;
            public GetFeiraByDistritoQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Feira> Handle(GetFeiraByDistritoQuery request, CancellationToken cancellationToken)
            {
                var feira = _context.Feira.Where(a => a.Distrito.Contains(request.Distrito)).FirstOrDefault();
                if (feira == null) return null;
                return feira;
            }
        }
    }
}
