namespace IBGEChallenge.Application.DTOs
{
    public class LocalityDTO
    {
        public long Id { get; set; }
        public string IBGECode { get; set; }
        public string Name { get; set; }
        public long StateId { get; set; }
        public StateDTO? State { get; set; }
    }
}