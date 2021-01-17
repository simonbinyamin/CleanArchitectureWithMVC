using mediatR.Business.Common.Interfaces;
using mediatR.DomainLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR.Business.CompanyItems.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = new Company
            {
                Name = request.Name
            };

            _context.Companies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
