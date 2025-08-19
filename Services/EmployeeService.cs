
public class EmployeeService : IEmployeeService
{
    
    public Task<AddEmployeeResponseDto> AddNewEmployee(AddEmployeeRequestDto employee)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<GetEmployeeResponseDto>> GetEmployees()
    {
        throw new NotImplementedException();
    }
}