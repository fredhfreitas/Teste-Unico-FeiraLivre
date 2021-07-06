using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unico.FeiraLivre.Domain.Entities;
using Unico.FeiraLivre.Persistence;

namespace Unico.FeiraLivre.Service.Features.FeiraFeatures.Queries
{
    public class GetAllFeiraQuery : IRequest<IEnumerable<Feira>>
    {

        public class GetAllFeiraQueryHandler : IRequestHandler<GetAllFeiraQuery, IEnumerable<Feira>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllFeiraQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Feira>> Handle(GetAllFeiraQuery request, CancellationToken cancellationToken)
            {
                var feiraList = await _context.Feira.ToListAsync();
                if (feiraList == null)
                {
                    return null;
                }
                return feiraList.AsReadOnly();
            }
        }
    }
}
