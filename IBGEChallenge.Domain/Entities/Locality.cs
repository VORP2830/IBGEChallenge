using IBGEChallenge.Domain.Exceptions;

namespace IBGEChallenge.Domain.Entities
{
    public class Locality : BaseEntity
    {
        public string IBGECode { get; protected set; }
        public string Name { get; protected set; }
        public long StateId { get; set; }
        public State State { get; set; }
        protected Locality() { }
        public Locality(string ibgeCode, string name, long stateId)
        {
            ValidateDomain(ibgeCode, name);
            StateId = stateId;
            Active = true;  
        }
        private void ValidateDomain(string ibgeCode, string name)
        {
            IBGEException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            IBGEException.When(name.Length < 3, "Nome deve contar mais de 3 caracteres");
            IBGEException.When(!IsNumeric(ibgeCode), "Codigo IBGE só deve conter números");
            IBGEException.When(string.IsNullOrEmpty(ibgeCode), "Codigo IBGE é obrigatório");
            IBGEException.When(ibgeCode.Length < 3, "Codigo IBGE deve conter mais de 3 caracteres");
            Name = name.Trim();
            IBGECode = ibgeCode.Trim();
        }
        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}