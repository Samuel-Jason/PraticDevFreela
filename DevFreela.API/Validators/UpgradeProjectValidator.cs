using DevFreela.Application.Services.Interfaces;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class UpgradeProjectValidator : AbstractValidator<UpdateProjectInputModel>
    {
        public UpgradeProjectValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("O ID não pode estar vazio.");

            RuleFor(p => p.Title)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(150)
                .WithMessage("O Titulo não pode estar vazio.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("A Descrição não pode estar vazio.");

            RuleFor(p => p.TotalCost)
                .NotEmpty()
                .WithMessage("O valor não pode estar vazio.");
        }
    }
}
