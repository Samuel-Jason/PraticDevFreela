using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(300)
                .WithMessage("Tamanho maximo é 300");


            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Maximo do titulo é igual a 30");
        }
    }
}
