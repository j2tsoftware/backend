using FluentValidation;

namespace Domain.Integracao.Clientes
{
    public class ClienteValidator : AbstractValidator<Cliente>        
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Documento).NotEmpty().WithMessage("O documento é obrigatório");
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório");
            RuleFor(x => x.TipoPessoa).NotEmpty().WithMessage("O tipo de pessoa é obrigatório");
            RuleFor(x => x.DataInicioRelacionamento).NotNull().WithMessage("A data de início do relacionamento é obrigatória");
        }
    }
}
