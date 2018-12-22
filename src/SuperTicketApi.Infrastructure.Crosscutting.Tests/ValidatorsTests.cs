namespace SuperTicketApi.Infrastructure.Crosscutting.Tests
{
    using System.Linq;

    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Validator;
    using SuperTicketApi.Infrastructure.Crosscutting.Tests.Classes;
    using SuperTicketApi.Infrastructure.Crosscutting.Validator;

    using Xunit;

    public class ValidatorsTests
    {
        #region Class Initialize

        public ValidatorsTests()
        {
            // Initialize default log factory
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }

        #endregion

        [Fact()]
        public void PerformValidationIsValidReturnFalseWithInvalidEntities()
        {
            //Arrange
            var entityA = new EntityWithValidationAttribute();
            entityA.RequiredProperty = null;

            var entityB = new EntityWithValidatableObject();
            entityB.RequiredProperty = null;

            IEntityValidator entityValidator = EntityValidatorFactory.CreateValidator();

            //Act
            var entityAValidationResult = entityValidator.IsValid(entityA);
            var entityAInvalidMessages = entityValidator.GetInvalidMessages(entityA);

            var entityBValidationResult = entityValidator.IsValid(entityB);
            var entityBInvalidMessages = entityValidator.GetInvalidMessages(entityB);

            //Assert
            Assert.False(entityAValidationResult);
            Assert.False(entityBValidationResult);

            Assert.True(entityAInvalidMessages.Any());
            Assert.True(entityBInvalidMessages.Any());

        }
        [Fact()]
        public void PerformValidationIsValidReturnTrueWithValidEntities()
        {
            //Arrange
            var entityA = new EntityWithValidationAttribute();
            entityA.RequiredProperty = "the data";

            var entityB = new EntityWithValidatableObject();
            entityB.RequiredProperty = "the data";

            IEntityValidator entityValidator = EntityValidatorFactory.CreateValidator();

            //Act
            var entityAValidationResult = entityValidator.IsValid(entityA);
            var entityAInvalidMessages = entityValidator.GetInvalidMessages(entityA);

            var entityBValidationResult = entityValidator.IsValid(entityB);
            var entityBInvalidMessages = entityValidator.GetInvalidMessages(entityB);

            //Assert
            Assert.True(entityAValidationResult);
            Assert.True(entityBValidationResult);

            Assert.False(entityAInvalidMessages.Any());
            Assert.False(entityBInvalidMessages.Any());

        }
    }
}
