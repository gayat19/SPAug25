using employeeapp.api.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IRepository<int, Employee> _employeeRepository;

    public EmployeeController(IRepository<int,Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetEmployees()
    {
        var employees = await _employeeRepository.GetAll();
        if (employees.Count() > 0)
            return Ok(employees);
        return NotFound("No Employees present");
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Anymethod([FromBody] Employee employee)
    {
        var result = await _employeeRepository.Add(employee);
        return Created("", result);
    }

}