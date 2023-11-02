namespace IBGEChallenge.Domain.Filter
{
    public class LocalityFilter : BaseFilter
    {
        public string IBGECode { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
    }
}