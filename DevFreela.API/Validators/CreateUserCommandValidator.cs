using FluentValidation;

namespace DevFreela.API.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandValidator>
    {
        public CreateUserCommandValidator(object password, object email)
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("");

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

        public string Password { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }

    }
}
