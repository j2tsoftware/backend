namespace Domain.Shared.Utils
{
    public static class ValueResultExtensions
    {
        public static Task<ValueResult> AsCompletedTask(this ValueResult @this) =>
            Task.FromResult(@this);

        public static Task<ValueResult<TResultValue>> AsCompletedTask<TResultValue>(
            this ValueResult<TResultValue> @this) =>
            Task.FromResult(@this);

        public static ValueTask<ValueResult> AsCompletedValueTask(this ValueResult @this) =>
            new ValueTask<ValueResult>(@this);

        public static ValueTask<ValueResult<TResultValue>> AsCompletedValueTask<TResultValue>(
            this ValueResult<TResultValue> @this) =>
            new ValueTask<ValueResult<TResultValue>>(@this);
    }
}
