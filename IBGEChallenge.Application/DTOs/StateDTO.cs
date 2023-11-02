namespace IBGEChallenge.Application.DTOs
{
    public class StateDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LocalityDTO>? Localities { get; set; } 
    }
}