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
    public class GetCompaniesByIdOrNameQuery: IRequest<IList<CompanyDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetCompaniesByIdOrNameQueryHandler : IRequestHandler<GetCompaniesByIdOrNameQuery, IList<CompanyDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompaniesByIdOrNameQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<CompanyDto>> Handle(GetCompaniesByIdOrNameQuery request, CancellationToken cancellationToken)
        {
            //var g = await _context.Companies.AsNoTracking().ProjectTo<CompanyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            //return await _context.Companies
            //    .Where(x => x.ListId == request.ListId)
            //    .OrderBy(x => x.Title)
            //    .ProjectTo<TodoItemDto>(_mapper.ConfigurationProvider)
            //    .PaginatedListAsync(request.PageNumber, request.PageSize); 

            var final =
                await (from x in _context.Companies 
                where x.Id==request.Id || x.Name == request.Name
                select x).ProjectTo<CompanyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return final;

        }
    }
}
