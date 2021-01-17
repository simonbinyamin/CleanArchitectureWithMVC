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

namespace mediatR.Business.CompanyItems.Commands.UpdateCompany
{
   public class UpdateCompanyCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            entity.Name = request.Name;


            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
