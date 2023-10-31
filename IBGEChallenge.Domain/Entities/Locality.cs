using IBGEChallenge.Domain.Exceptions;

namespace IBGEChallenge.Domain.Entities
{
    public class Locality : BaseEntity
    {
        public string IBGECode { get; protected set; }
        public long CityId { get; protected set; }
        public City City { get; protected set; }
        protected Locality() { }
        public Locality(long cityId, string ibgeCode)
        {
            ValidateDomain(ibgeCode);
            CityId = cityId;
            Active = true;  
        }
        private void ValidateDomain(string ibgeCode)
        {
            IBGEException.When(!IsNumeric(ibgeCode), "Codigo IBGE é so deve conter numeros");
            IBGEException.When(string.IsNullOrEmpty(ibgeCode), "Codigo IBGE é obrigatório");
            IBGEException.When(ibgeCode.Length < 3, "Codigo IBGE deve contar mais de 3 caracteres");
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