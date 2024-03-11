using FluentValidation;

namespace Domain.Gerenciamento.Usuarios
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("O e-mail é obrigatório");
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório");
            RuleFor(x => x.Username).NotEmpty().WithMessage("O username é obrigatório");
        }
    }
}
