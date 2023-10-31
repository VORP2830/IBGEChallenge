using IBGEChallenge.Domain.Exceptions;

namespace IBGEChallenge.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; protected set; }
        public long StateId { get; protected set; }
        public State State { get; protected set; }
        public IEnumerable<Locality> Localities { get; protected set; }
        protected City() { }
        public City(string name, long stateId)
        {
            ValidateDomain(name);
            StateId = stateId;
            Active = true;
        }
        private void ValidateDomain(string name)
        {
            IBGEException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            IBGEException.When(name.Length < 3, "Nome deve contar mais de 3 caracteres");
            Name = name.Trim();
        }
    }
}