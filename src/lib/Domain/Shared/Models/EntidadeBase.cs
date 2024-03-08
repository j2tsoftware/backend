using Domain.Shared.Utils;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shared.Models
{
    public class EntidadeBase
    {
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        [NotMapped]
        public bool DadosValidos { get; private set; }

        [NotMapped]
        public bool DadosInvalidos => !DadosValidos;

        [NotMapped]
        public ValidationResult Validacoes { get; private set; }

        [NotMapped]
        public IEnumerable<ValueFailureDetail> Falhas => Erros();

        public EntidadeBase()
        {
            DataAtualizacao = DateTime.Now;
        }

        public bool Validar<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            if (validator is null)
                ArgumentNullException.ThrowIfNull(nameof(validator));

            Validacoes = validator.Validate(model);

            return DadosValidos = Validacoes.IsValid;
        }

        private IEnumerable<ValueFailureDetail> Erros()
        {
            return Validacoes?.Errors?.Select(x => new ValueFailureDetail(x.ErrorMessage, x.ErrorCode));
        }
    }
}
