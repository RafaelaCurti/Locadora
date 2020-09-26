using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Locadora.Domain;
using FluentValidation;
using Simple;

namespace Locadora.Validators
{
    public class TMovieValidator : AbstractValidator<TMovie>
    {
        public TMovieValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo nome deve ser preenchido.");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("O campo estoque deve ter uma quantidade maior ou igual a 0");
        }
    }
}
