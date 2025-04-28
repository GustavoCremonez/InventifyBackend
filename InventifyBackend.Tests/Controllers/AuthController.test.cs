using Bogus;
using InventifyBackend.Api.Controllers;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Application.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InventifyBackend.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Faker _faker = new("pt_BR");
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AuthController _authController;

        public AuthControllerTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _authController = new AuthController(_mockAuthService.Object);
        }

        
    }
}
