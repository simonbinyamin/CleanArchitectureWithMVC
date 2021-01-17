using mediatR.Business.Common.Mappings;
using mediatR.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatR.Business.CompanyItems.Queries.GetCompanies
{
    public class CompanyDto: IMapFrom<Company>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
