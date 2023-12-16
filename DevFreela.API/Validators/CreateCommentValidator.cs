using DevFreela.API.Models;
using DevFreela.Application.Services.Interfaces;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentInputModel>
    {
        public CreateCommentValidator()
        {
            RuleFor(p => p.Content)
                .NotEmpty()
                .WithMessage("Conteudo vazio");

            RuleFor(p => p.IdUser)
                .NotEmpty()
                .WithMessage("Id do usuario esta vazio");

            RuleFor(p => p.IdProject)
                .NotEmpty()
                .WithMessage("Id do Projeto esta vazio");
        }
    }
}
