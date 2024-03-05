using FluentValidation;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public class AtualizacaoRelacionamentoValidator : AbstractValidator<AtualizacaoRelacionamento>
    {
        public AtualizacaoRelacionamentoValidator()
        {
            RuleFor(x => x.NumeroRemessa).NotEmpty().WithMessage("O número da remessa é obrigatório");
            RuleFor(x => x.QuantidadeOperacao).NotEmpty().WithMessage("A quantidade de clientes deve ser informada");
            
            RuleFor(x => x.Clientes)
                .ForEach(x => x.SetValidator(new AtualizacaoRelacionamentoClienteValidator()));
        }
    }
}
