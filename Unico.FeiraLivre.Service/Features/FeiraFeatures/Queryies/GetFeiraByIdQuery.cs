using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unico.FeiraLivre.Domain.Entities;
using Unico.FeiraLivre.Persistence;

namespace Unico.FeiraLivre.Service.Features.FeiraFeatures.Queries
{
    public class GetFeiraByIdQuery : IRequest<Feira>
    {
        public int Id { get; set; }
        public class GetFeiraByIdQueryHandler : IRequestHandler<GetFeiraByIdQuery, Feira>
        {
            private readonly IApplicationDbContext _context;
            public GetFeiraByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Feira> Handle(GetFeiraByIdQuery request, CancellationToken cancellationToken)
            {
                var feira = _context.Feira.Where(a => a.Id == request.Id).FirstOrDefault();
                if (feira == null) return null;
                return feira;
            }
        }
    }
}
