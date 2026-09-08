using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Practise_Project_3.Controllers;
using Practise_Project_3.Models;
using Practise_Project_3.Services;

namespace Practise_Project_3.Tests;

[TestFixture]
public sealed class StudentControllerTests
{
    private Mock<IStudentService> _service = null!;
    private StudentController _controller = null!;

    [SetUp]
    public void SetUp()
    {
        _service = new Mock<IStudentService>();
        _controller = new StudentController(_service.Object);
    }

    [Test]
    public void GetStudentById_WhenMissing_ReturnsNotFound()
    {
        _service.Setup(x => x.GetStudentById(10)).Returns((Student?)null);

        var result = _controller.GetStudentById(10);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void GetAllStudents_ReturnsOk()
    {
        _service.Setup(x => x.GetAllStudents()).Returns([]);

        var result = _controller.GetAllStudents();

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
    }
}
