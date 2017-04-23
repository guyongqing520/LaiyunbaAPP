using Infrastructure.Crosscutting.NetFramework.Validator;
using Infrastructure.Crosscutting.Tests.Classes;
using Infrastructure.Crosscutting.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Crosscutting.Tests
{
    [TestClass()]
    public class ValidatorsTests
    {
        #region Class Initialize

        [ClassInitialize()]
        public static void ClassInitialze(TestContext context)
        {
            // Initialize default log factory
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }

        #endregion


        [TestMethod()]
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
            Assert.IsFalse(entityAValidationResult);
            Assert.IsFalse(entityBValidationResult);

            Assert.IsTrue(entityAInvalidMessages.Any());
            Assert.IsTrue(entityBInvalidMessages.Any());

        }
        [TestMethod()]
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
            Assert.IsTrue(entityAValidationResult);
            Assert.IsTrue(entityBValidationResult);

            Assert.IsFalse(entityAInvalidMessages.Any());
            Assert.IsFalse(entityBInvalidMessages.Any());

        }
    }
}
