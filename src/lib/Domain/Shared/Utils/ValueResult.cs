namespace Domain.Shared.Utils
{
    /// <summary>
    /// Suporta o Notification Pattern: situações em que é indesejável lançar exceptions: validação de regras de negócio em web servers (overhead).
    /// </summary>
    /// <typeparam name="TResultValue"></typeparam>
    public class ValueResult<TResultValue>
    {
        public bool Succeeded { get; private set; }
        public TResultValue Value { get; private set; }
        public IReadOnlyCollection<ValueFailureDetail> FailureDetails { get; private set; }

        public ValueResult AsValueResult() =>
            this
                ? ValueResult.Success()
                : ValueResult.Failure(FailureDetails);

        public static ValueResult<TResultValue> Success(TResultValue value) =>
            new() { Succeeded = true, Value = value, FailureDetails = Array.Empty<ValueFailureDetail>() };

        public static ValueResult<TResultValue> Failure() =>
            new() { Succeeded = false, FailureDetails = Array.Empty<ValueFailureDetail>() };

        public static ValueResult<TResultValue> Failure(IEnumerable<ValueFailureDetail>? detalhesFalhas) =>
            new() { Succeeded = false, FailureDetails = (detalhesFalhas?.ToArray()) ?? Array.Empty<ValueFailureDetail>() };

        public static ValueResult<TResultValue> Failure(
            TResultValue value, IEnumerable<ValueFailureDetail> failureDetails) =>
            new() { Succeeded = false, Value = value, FailureDetails = (failureDetails?.ToArray()) ?? Array.Empty<ValueFailureDetail>() };

        public static ValueResult<TResultValue> Failure(params string[] descricoes) =>
            Failure(descricoes?.Select(x => (ValueFailureDetail)x));

        public static ValueResult<TResultValue> Failure(
            params (string description, string tag)[] descriptions) =>
                 Failure(descriptions?.Select(x => new ValueFailureDetail(x.description, x.tag)));

        public static implicit operator bool(ValueResult<TResultValue> valueResult) =>
            valueResult.Succeeded;


        public static implicit operator ValueResult(ValueResult<TResultValue> valueResult) =>
            valueResult.AsValueResult();
    }

    public struct ValueResult
    {
        private static readonly ValueFailureDetail[] EmptyFailureDetails = Array.Empty<ValueFailureDetail>();

        public bool Succeeded { get; private set; }
        public IReadOnlyCollection<ValueFailureDetail> FailureDetails { get; private set; }

        public static ValueResult Success() =>
            new() { Succeeded = true, FailureDetails = EmptyFailureDetails };

        public static ValueResult Failure(IEnumerable<ValueFailureDetail>? failureDetails) =>
            new() { Succeeded = false, FailureDetails = (failureDetails?.ToArray()) ?? EmptyFailureDetails };

        public static ValueResult Failure() =>
            new() { Succeeded = false, FailureDetails = EmptyFailureDetails };

        public static ValueResult Failure(params string[] descriptions) =>
            Failure(descriptions?.Select(x => (ValueFailureDetail)x));

        public static ValueResult Failure(
            params (string description, string tag)[] descriptions) =>
                 Failure(descriptions?.Select(x => new ValueFailureDetail(x.description, x.tag)));

        public static implicit operator bool(ValueResult valueResult) => valueResult.Succeeded;
    }
}
