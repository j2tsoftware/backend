namespace Domain.Shared.Utils
{
    public class ValueFailureDetail
    {
        public string Tag { get; }
        public string Description { get; private set; }

        public ValueFailureDetail(string description, string tag = null)
        {
            Tag = string.IsNullOrEmpty(tag) ? "-" : tag;
            Description = description;
        }

        public static implicit operator ValueFailureDetail(string description) 
            => new (description);
    }
}
