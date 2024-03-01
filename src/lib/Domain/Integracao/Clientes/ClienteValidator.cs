using FluentValidation;

namespace Domain.Integracao.Clientes
{
    public class ClienteValidator : AbstractValidator<Cliente>        
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Documento).NotEmpty();
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.TipoPessoa).NotEmpty();
            RuleFor(x => x.DataInicioRelacionamento).NotNull();
        }
    }
}
