using FluentValidation;
using peryautWebApi.Dtos;

namespace peryautWebApi.Validators
{
    public class PostAutoDtoValidator : AbstractValidator<PostAutoDto>
    {
        public PostAutoDtoValidator()
        {
            RuleFor(x => x.nombrepost)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5).WithMessage("Minimo 5 Caracteres");
            RuleFor(x => x.aniopost)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10).WithMessage("Largo maximo 10");
            RuleFor(x => x.colorpost)
                .NotEmpty();
        }
    }
}

