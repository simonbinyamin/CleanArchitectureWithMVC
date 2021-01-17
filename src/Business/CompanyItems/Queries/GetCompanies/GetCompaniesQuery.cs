using AutoMapper;
using AutoMapper.QueryableExtensions;
using mediatR.Business.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR.Business.CompanyItems.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<IList<CompanyDto>>
    {
    }

    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IList<CompanyDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var g = await _context.Companies.AsNoTracking().ProjectTo<CompanyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return g;
   
        }
    }


}
