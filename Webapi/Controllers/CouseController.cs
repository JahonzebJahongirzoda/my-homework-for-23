using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly CourseServices _service;

    public CourseController(CourseServices service)
    {
        _service = service;
    }


    [HttpGet("GetallfromCourse")]
    public async Task<string> Get()

    {
        return await _service.GetallfromCourse();
    }




    [HttpPut("UpdateCourse")]
    public async Task<string> Put(Course Course)

    {
        return await _service.UpdateCourse(Course);
    }










    [HttpDelete("DeleteCourse")]
    public async Task<string> Delete(int id)

    {
        return await _service.DeleteCourse(id);
    }






    [HttpPost("AddCourse")]
    public async Task<string> Create(Course Course)
    {
        return await _service.AddCourse(Course);

    }







}
