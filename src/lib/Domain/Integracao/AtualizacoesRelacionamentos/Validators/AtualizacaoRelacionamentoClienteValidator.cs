using FluentValidation;

namespace Domain.Integracao.AtualizacoesRelacionamentos
{
    public class AtualizacaoRelacionamentoClienteValidator : AbstractValidator<AtualizacaoRelacionamentoCliente>
    {
        public AtualizacaoRelacionamentoClienteValidator()
        {
            RuleFor(x => x.Documento).NotEmpty().WithMessage("O documento é obrigatório");
            RuleFor(x => x.TipoOperacao).NotEmpty().WithMessage("O tipo de oporação é obrigatória");
            RuleFor(x => x.QualificadorOperacao).NotEmpty().WithMessage("O qualificador da operação é obrigatório");
            RuleFor(x => x.DataInicioRelacionamento).NotNull().WithMessage("A data de inicio de relacionamento é obrigatória");
        }
    }
}
