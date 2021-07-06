using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unico.FeiraLivre.Persistence;

namespace Unico.FeiraLivre.Service.Features.FeiraFeatures.Commands
{
    public class DeleteFeiraByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteFeiraByIdCommandHandler : IRequestHandler<DeleteFeiraByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteFeiraByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteFeiraByIdCommand request, CancellationToken cancellationToken)
            {
                var customer = await _context.Feira.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (customer == null) return default;
                _context.Feira.Remove(customer);
                await _context.SaveChangesAsync();
                return customer.Id;
            }
        }
    }
}
