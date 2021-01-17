using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatR.Business.CompanyItems.Commands.UpdateCompany
{
    class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}