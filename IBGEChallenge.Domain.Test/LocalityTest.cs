using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Exceptions;

namespace IBGEChallenge.Domain.Test
{
    public class LocalityTest
    {
        [Fact(DisplayName = "Locality should be able to set correct IBGECode, Name, and StateId")]
        public void Locality_CanSetCorrectIBGECodeNameAndStateId()
        {
            // Arrange
            string ibgeCode = "12345";
            string name = "Example Locality";
            long stateId = 1;

            // Act
            var locality = new Locality(ibgeCode, name, stateId);

            // Assert
            Assert.Equal(ibgeCode, locality.IBGECode);
            Assert.Equal(name, locality.Name);
            Assert.Equal(stateId, locality.StateId);
        }

        [Fact(DisplayName = "Locality should trim whitespace from IBGECode, Name, and StateId")]
        public void Locality_TrimsWhitespaceFromIBGECodeNameAndStateId()
        {
            // Arrange
            string ibgeCode = "54321";
            string name = "  Another Locality  ";
            long stateId = 2;

            // Act
            var locality = new Locality(ibgeCode, name, stateId);

            // Assert
            Assert.Equal("54321", locality.IBGECode);
            Assert.Equal("Another Locality", locality.Name);
            Assert.Equal(stateId, locality.StateId);
        }

        [Fact(DisplayName = "Locality should throw exception when IBGECode is not numeric")]
        public void Locality_ThrowsExceptionWhenIBGECodeIsNotNumeric()
        {
            // Arrange
            string ibgeCode = "AB123";
            string name = "Invalid Locality";
            long stateId = 3;

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new Locality(ibgeCode, name, stateId));
            Assert.Equal("Codigo IBGE só deve conter números", exception.Message);
        }

        [Fact(DisplayName = "Locality should throw exception when IBGECode is null or empty")]
        public void Locality_ThrowsExceptionWhenIBGECodeIsNullOrEmpty()
        {
            // Arrange
            string ibgeCode = "";
            string name = "Empty IBGECode Locality";
            long stateId = 4;

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new Locality(ibgeCode, name, stateId));
            Assert.Equal("Codigo IBGE é obrigatório", exception.Message);
        }

        [Fact(DisplayName = "Locality should throw exception when IBGECode length is less than 3")]
        public void Locality_ThrowsExceptionWhenIBGECodeLengthIsLessThan3()
        {
            // Arrange
            string ibgeCode = "12";
            string name = "Short IBGECode Locality";
            long stateId = 5;

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new Locality(ibgeCode, name, stateId));
            Assert.Equal("Codigo IBGE deve conter mais de 3 caracteres", exception.Message);
        }

        [Fact(DisplayName = "Locality should throw exception when Name is null or empty")]
        public void Locality_ThrowsExceptionWhenNameIsNullOrEmpty()
        {
            // Arrange
            string ibgeCode = "54321";
            string name = "";
            long stateId = 6;

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new Locality(ibgeCode, name, stateId));
            Assert.Equal("Nome é obrigatório", exception.Message);
        }

        [Fact(DisplayName = "Locality should throw exception when Name length is less than 3")]
        public void Locality_ThrowsExceptionWhenNameLengthIsLessThan3()
        {
            // Arrange
            string ibgeCode = "54321";
            string name = "Ab";
            long stateId = 7;

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new Locality(ibgeCode, name, stateId));
            Assert.Equal("Nome deve contar mais de 3 caracteres", exception.Message);
        }

        [Fact(DisplayName = "Locality should have Active property set to true by default")]
        public void Locality_ActiveIsSetToTrueByDefault()
        {
            // Arrange
            string ibgeCode = "12345";
            string name = "Default Active Locality";
            long stateId = 8;

            // Act
            var locality = new Locality(ibgeCode, name, stateId);

            // Assert
            Assert.True(locality.Active);
        }
    }
}
