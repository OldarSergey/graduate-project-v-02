using GraduateProjectAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateProjectAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employees)
    {
        _employeeService = employees;
    }
    [HttpGet]
    public async Task<IActionResult> GetListEmployee(string sortingOptions = "ots")
    {
        var result = await _employeeService.GetListEmployee();
        if (!string.IsNullOrWhiteSpace(sortingOptions))
        {

            switch (sortingOptions)
            {
                case "По фамилии":

                    var sortByFullName = result.OrderBy(e => e.FullName).ToList();
                    result = sortByFullName;
                    break;

                case "По должности":

                    var sortByDuty = result.OrderBy(e => e.Duty).ToList();
                    result = sortByDuty;
                    break;
                case "По отделу":

                    var sortByDepartment = result.OrderBy(e => e.Department).ToList();
                    result = sortByDepartment;
                    break;
            }
        }
        return Ok(result);
    }
}
