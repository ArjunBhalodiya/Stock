using FluentValidation;
using Stock.Models;

namespace Stock.Valiidator
{
    public class CompanyDetailsValidator : AbstractValidator<CompanyDetailVm>
    {
        public CompanyDetailsValidator()
        {
            RuleFor(p => p.SecurityId).NotEmpty().WithMessage("SecurityId cannot be blank.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("SecurityId cannot be blank.");
            RuleFor(p => p.Index).NotEmpty().WithMessage("Index cannot be blank.");
            RuleFor(p => p.SecurityCode).NotEmpty().WithMessage("SecurityCode cannot be blank.")
                                        .GreaterThan(0).WithMessage("SecurityCode must be grater than zero.");
            RuleFor(p => p.ISIN).NotEmpty().WithMessage("ISIN cannot be blank.");
            RuleFor(p => p.Industries).NotEmpty().WithMessage("Industries cannot be blank.");
        }
    }
}