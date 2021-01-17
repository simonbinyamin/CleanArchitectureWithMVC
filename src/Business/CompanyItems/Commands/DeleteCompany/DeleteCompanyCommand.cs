using mediatR.Business.Common.Exceptions;
using mediatR.Business.Common.Interfaces;
using mediatR.DomainLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR.Business.CompanyItems.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            _context.Companies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
