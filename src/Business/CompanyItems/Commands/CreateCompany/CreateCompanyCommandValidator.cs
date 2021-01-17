using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediatR.Business.CompanyItems.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
        }

    }
}
