using DevFreela.API.Models;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandModel>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email incorreto");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Erro na senha");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome completo obrigatorio");
        }

        private bool ValidPassword(object arg)
        {
            throw new NotImplementedException();
        }
    }
}
