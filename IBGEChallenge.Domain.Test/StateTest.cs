using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Exceptions;

namespace IBGEChallenge.Domain.Test
{
    public class StateTest
    {
        [Fact(DisplayName = "State should be able to set correct name")]
        public void State_CanSetCorrectName()
        {
            // Arrange
            string name = "Rio de Janeiro";

            // Act
            var state = new State(name);

            // Assert
            Assert.Equal(name, state.Name);
        }

        [Fact(DisplayName = "State should trim whitespace from name")]
        public void State_TrimsWhitespaceFromName()
        {
            // Arrange
            string name = "  São Paulo  ";

            // Act
            var state = new State(name);

            // Assert
            Assert.Equal("São Paulo", state.Name);
        }

        [Fact(DisplayName = "State should throw exception when name is null or empty")]
        public void State_ThrowsExceptionWhenNameIsNullOrEmpty()
        {
            // Arrange
            string name = "";

            // Act & Assert
            Assert.Throws<IBGEException>(() => new State(name));
        }

        [Fact(DisplayName = "State should throw exception when name length is less than 3")]
        public void State_ThrowsExceptionWhenNameLengthIsLessThan3()
        {
            // Arrange
            string name = "NY";

            // Act & Assert
            Assert.Throws<IBGEException>(() => new State(name));
        }

        [Fact(DisplayName = "State active property should be set to true by default")]
        public void State_ActiveIsSetToTrueByDefault()
        {
            // Arrange
            string name = "Texas";

            // Act
            var state = new State(name);

            // Assert
            Assert.True(state.Active);
        }

        [Fact(DisplayName = "State should throw exception with message when name is null or empty")]
        public void State_ThrowsExceptionWithMessageWhenNameIsNullOrEmpty()
        {
            // Arrange
            string name = "";

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new State(name));
            Assert.Equal("Nome é obrigatório", exception.Message);
        }

        [Fact(DisplayName = "State should throw exception with message when name length is less than 3")]
        public void State_ThrowsExceptionWithMessageWhenNameLengthIsLessThan3()
        {
            // Arrange
            string name = "AZ";

            // Act & Assert
            var exception = Assert.Throws<IBGEException>(() => new State(name));
            Assert.Equal("Nome deve contar mais de 3 caracteres", exception.Message);
        }

        [Fact(DisplayName = "State should set correct name with whitespace trimmed")]
        public void State_SetsCorrectNameWithWhitespaceTrimmed()
        {
            // Arrange
            string name = "  California  ";

            // Act
            var state = new State(name);

            // Assert
            Assert.Equal("California", state.Name);
        }
    }
}
