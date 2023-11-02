using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Exceptions;
using Xunit;

namespace IBGEChallenge.Domain.Test
{
    public class UserTest
    {
        [Fact(DisplayName = "User should be able to set correct Name, Email, and Password")]
        public void User_CanSetCorrectNameEmailAndPassword()
        {
            // Arrange
            string name = "John Doe";
            string email = "john.doe@example.com";
            string password = "SecurePassword123";

            // Act
            var user = new User(name, email, password);

            // Assert
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
            Assert.Equal(password, user.Password);
        }

        [Fact(DisplayName = "User should throw exception when Name is null or empty")]
        public void User_ThrowsExceptionWhenNameIsNullOrEmpty()
        {
            // Arrange
            string name = "";
            string email = "jane@example.com";
            string password = "Secure123";

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new User(name, email, password));
            Assert.Equal("Nome é obrigatório", exception.Message);
        }

        [Fact(DisplayName = "User should throw exception when Name length is less than 3")]
        public void User_ThrowsExceptionWhenNameLengthIsLessThan3()
        {
            // Arrange
            string name = "A";
            string email = "dave@example.com";
            string password = "Secret123";

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new User(name, email, password));
            Assert.Equal("Nome deve conter mais de 3 caracteres", exception.Message);
        }

        [Fact(DisplayName = "User should throw exception when Email is null or empty")]
        public void User_ThrowsExceptionWhenEmailIsNullOrEmpty()
        {
            // Arrange
            string name = "Mary Johnson";
            string email = "";
            string password = "Password123";

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new User(name, email, password));
            Assert.Equal("Email é obrigatório", exception.Message);
        }

        [Fact(DisplayName = "User should throw exception when Email is invalid")]
        public void User_ThrowsExceptionWhenEmailIsInvalid()
        {
            // Arrange
            string name = "Rob Brown";
            string email = "invalid-email";
            string password = "Secure456";

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new User(name, email, password));
            Assert.Equal("Email inválido", exception.Message);
        }

        [Fact(DisplayName = "User should throw exception when Password is null or empty")]
        public void User_ThrowsExceptionWhenPasswordIsNullOrEmpty()
        {
            // Arrange
            string name = "Sarah Davis";
            string email = "sarah@example.com";
            string password = "";

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new User(name, email, password));
            Assert.Equal("Senha é obrigatória", exception.Message);
        }

        [Fact(DisplayName = "User should have Active property set to true by default")]
        public void User_ActiveIsSetToTrueByDefault()
        {
            // Arrange
            string name = "Michael Wilson";
            string email = "michael@example.com";
            string password = "Default123";

            // Act
            var user = new User(name, email, password);

            // Assert
            Assert.True(user.Active);
        }
    }
}
