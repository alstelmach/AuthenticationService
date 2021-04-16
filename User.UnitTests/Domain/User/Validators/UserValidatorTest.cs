using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using User.Domain.User.Exceptions;
using User.Domain.User.Factories;
using User.Domain.User.Repositories;
using User.Domain.User.Validators;
using Xunit;

namespace User.UnitTests.Domain.User.Validators
{
    public sealed class UserValidatorTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IMailAddressValidator> _mailAddressValidator = new();
        private readonly UserValidator _userValidator;

        public UserValidatorTest()
        {
            _userValidator = new UserValidator(
                _userRepositoryMock.Object,
                _mailAddressValidator.Object);
            
            _userRepositoryMock
                .Setup(repo =>
                    repo.CheckIsLoginFreeAsync(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(true);
            
            _userRepositoryMock
                .Setup(repo =>
                    repo.CheckIsMailAddressFreeAsync(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(true);
            
            _mailAddressValidator
                .Setup(validator =>
                    validator.Validate(It.IsAny<string>()))
                .Returns(true);
        }
        
        [Fact]
        public async Task ShouldAcceptValidUser()
        {
            // Arrange
            var user = UserFactory.Create(
                Guid.NewGuid(),
                "astelmach",
                Array.Empty<byte>(),
                "Aleksander",
                "Stelmach",
                "alstelmach@outlook.com");

            // Act
            var validationResults = await _userValidator.ValidateAsync(user);

            // Assert
            Assert.Empty(validationResults.Errors);
        }
        
        [Fact]
        public async Task ShouldRejectTakenLogin()
        {
            // Arrange
            _userRepositoryMock
                .Setup(repo =>
                    repo.CheckIsLoginFreeAsync(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(false);
            
            var user = UserFactory.Create(
                Guid.NewGuid(),
                "anowacki",
                Array.Empty<byte>(),
                "Adam",
                "Nowacki",
                "anowacki@gmail.com");
            
            // Act
            Task ValidationResults() => _userValidator.ValidateAsync(user);
            
            // Arrange
            await Assert.ThrowsAsync<UserLoginUniquenessException>(ValidationResults);
        }
        
        [Fact]
        public async Task ShouldRejectTakenMailAddress()
        {
            // Arrange
            _userRepositoryMock
                .Setup(repo =>
                    repo.CheckIsMailAddressFreeAsync(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(false);
            
            var user = UserFactory.Create(
                Guid.NewGuid(),
                "bnowak",
                Array.Empty<byte>(),
                "Barbara",
                "Nowak",
                "ajaworek@gmail.com");
            
            // Act
            Task ValidationResults() => _userValidator.ValidateAsync(user);
            
            // Arrange
            await Assert.ThrowsAsync<UserMailAddressUniquenessException>(ValidationResults);
        }
    }
}
