using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdminHelper.models.entities;

namespace AdminHelper.Models.Tests
{
    [TestClass()]
    public class EntityValidatorTests
    {

        //тесты пишутся в формате AAA (Arrange, Act, Assert)
        //Arange - определение данных
        //Act - вызов метода
        //Assert - сверка результатов
        [TestMethod()]
        public void IsValid_ActorRight_Test()
        {
            //Arrange
            var actor = new Actor
            {
                LastName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович"
            };

            //Act
            var result = actor.IsValid();

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void IsValid_ActorLongName_Test()
        {
            //Arrange
            var actor = new Actor
            {
                LastName = "ИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИванов",
                FirstName = "ИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИванов",
                Patronymic = "ИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИвановИванов"
            };

            //Act
            var result = actor.IsValid();

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void IsValid_ActorEmptyName_Test()
        {
            //Arrange
            var actor = new Actor
            {
                LastName = string.Empty,
                FirstName = string.Empty,
                Patronymic = string.Empty
            };

            //Act
            var result = actor.IsValid();

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void IsValid_ActorNullName_Test()
        {
            //Arrange
            var actor = new Actor
            {
                LastName = null!,
                FirstName = null!,
                Patronymic = null!
            };

            //Act
            var result = actor.IsValid();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsValid_FullnessRight_Test()
        {
            var fullness = new Fullness
            {
                FullnessName = "0-50%",
                Allowance = 120
            };

            var result = fullness.IsValid();

            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void IsValid_FullnessNameNull_Test()
        {
            var fullness = new Fullness
            {
                FullnessName = null!,
                Allowance = 120
            };

            var result = fullness.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void IsValid_FullnessNameEmpty_Test()
        {
            var fullness = new Fullness
            {
                FullnessName = string.Empty,
                Allowance = 120
            };

            var result = fullness.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void IsValid_FullnessIncorrectAllowance_Test()
        {
            var fullness = new Fullness
            {
                FullnessName = "0-50%",
                Allowance = -99999
            };

            var result = fullness.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_RoleTypeRight_Test()
        {
            var roleType = new RoleType
            {
                Name = "массовка",
            };

            var result = roleType.IsValid();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValid_RoleTypeLongName_Test()
        {
            var roleType = new RoleType
            {
                Name = "массовкамассовкамассовкамассовкамассовкамассовкамассовкамассовкамассовкамассовкамассовкамассовкамассовкамассовкамассовка",
            };

            var result = roleType.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_RoleTypeNullName_Test()
        {
            var roleType = new RoleType
            {
                Name = null!,
            };

            var result = roleType.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_RoleTypeEmptyName_Test()
        {
            var roleType = new RoleType
            {
                Name = string.Empty,
            };

            var result = roleType.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_SpectacleRight_Test()
        {
            var spectacle = new Spectacle
            {
                Name = "Подруга жизни",
                Date = DateTime.Today
            };

            var result = spectacle.IsValid();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValid_SpectacleEmtptyName_Test()
        {
            var spectacle = new Spectacle
            {
                Name = string.Empty,
                Date = DateTime.Today
            };

            var result = spectacle.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_SpectacleNullName_Test()
        {
            var spectacle = new Spectacle
            {
                Name = null!,
                Date = DateTime.Today
            };

            var result = spectacle.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_SpectacleNullDate_Test()
        {
            var spectacle = new Spectacle
            {
                Name = "Подруга жизни",
                Date = null!
            };

            var result = spectacle.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_RoleRight_Test()
        {
            var role = new Role
            {
                NameNavigation = new RoleType(),
                ActorIdNavigation = new Actor(),
                SpectacleIdNavigation = new Spectacle(),
                Rate = 200
            };

            var result = role.IsValid();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValid_RoleNullNameNavigation_Test()
        {
            var role = new Role
            {
                NameNavigation = null!,
                ActorIdNavigation = new Actor(),
                SpectacleIdNavigation = new Spectacle(),
                Rate = 200
            };

            var result = role.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_RoleNullSpectacleNavigation_Test()
        {
            var role = new Role
            {
                NameNavigation = new RoleType(),
                ActorIdNavigation = new Actor(),
                SpectacleIdNavigation = null!,
                Rate = 200
            };

            var result = role.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_RoleNullActorNavigation_Test()
        {
            var role = new Role
            {
                NameNavigation = new RoleType(),
                ActorIdNavigation = null!,
                SpectacleIdNavigation = new Spectacle(),
                Rate = 200
            };

            var result = role.IsValid();

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsValid_RoleIncorrectRate_Test()
        {
            var role = new Role
            {
                NameNavigation = null!,
                ActorIdNavigation = new Actor(),
                SpectacleIdNavigation = new Spectacle(),
                Rate = -200
            };

            var result = role.IsValid();

            Assert.IsFalse(result);
        }
    }
}