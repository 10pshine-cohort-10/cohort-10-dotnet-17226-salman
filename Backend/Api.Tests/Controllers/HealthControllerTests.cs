
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace Api.Tests.Controllers;

public class HealthControllerTests
{
    [Fact]
    public void Get_ReturnsOk_WithRunningStatus()
    {
        // Arrange
        var controller = new HealthController();

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);

        var status = okResult.Value?.GetType().GetProperty("status")?.GetValue(okResult.Value);
        Assert.Equal("API is running", status);
    }
}