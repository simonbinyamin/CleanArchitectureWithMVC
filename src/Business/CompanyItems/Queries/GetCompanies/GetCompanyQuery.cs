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
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public int Id { get; set; }
    }


    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {

            var final =
                await (from x in _context.Companies
                       where x.Id == request.Id
                       select x).ProjectTo<CompanyDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            return final;

        }
    }
}
