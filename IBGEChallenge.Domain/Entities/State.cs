using IBGEChallenge.Domain.Exceptions;

namespace IBGEChallenge.Domain.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; protected set; }
        public IEnumerable<Locality> Localities { get; protected set; }
        protected State(){ }
        public State(string name)
        {
            ValidateDomain(name);
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