using System.Text.RegularExpressions;
using IBGEChallenge.Domain.Exceptions;

namespace IBGEChallenge.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        protected User(){ }
        public User(string name, string userName, string email, string password)
        {
            ValidateDomain(name, userName, email, password);
            Active = true;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        private void ValidateDomain(string name, string userName, string email, string password)
        {
            IBGEException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            IBGEException.When(name.Length < 3, "Nome deve conter mais de 3 caracteres");
            IBGEException.When(string.IsNullOrEmpty(email), "Email é obrigatório");
            IBGEException.When(IsInvalidEmail(email), "Email inválido");
            IBGEException.When(string.IsNullOrEmpty(password), "Senha é obrigatória");
            Name = name.Trim();
            UserName = userName.Trim().ToLower();
            Email = email.Trim().ToLower();
            Password = password;
        }
        private static bool IsInvalidEmail(string email)
        {
            email.Trim();
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return !Regex.IsMatch(email, pattern);
        }
    }
}