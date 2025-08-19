
using AutoMapper;
using employeeapp.api.Interfaces;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<int, Employee> _employeeRepository;
    private readonly IRepository<int, Department> _departmnetRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IRepository<int, Employee> employeeRepository,
                            IRepository<int, Department> departmnetRepository,
                            IMapper mapper
    )
    {
        _employeeRepository = employeeRepository;
        _departmnetRepository = departmnetRepository;
        _mapper = mapper;

    }
    public async Task<AddEmployeeResponseDto> AddNewEmployee(AddEmployeeRequestDto employee)
    {
        var departmnet = await _departmnetRepository.GetByKey(employee.DepartmentId);
        if (departmnet == null)
            throw new Exception("Invalid DepratmentId");
        var dbEmployee = _mapper.Map<Employee>(employee);
        dbEmployee = await _employeeRepository.Add(dbEmployee);
        var result = _mapper.Map<AddEmployeeResponseDto>(dbEmployee);
        result.DepartmnetName = departmnet.Name;
        return result;
    }

    public async Task<ICollection<GetEmployeeResponseDto>> GetEmployees()
    {
        var employees = await _employeeRepository.GetAll();
        if (employees.Count() == 0)
            throw new Exception("No employees found");
        List<GetEmployeeResponseDto> result = new List<GetEmployeeResponseDto>();
        foreach (var emp in employees)
        {
            var res = _mapper.Map<GetEmployeeResponseDto>(emp);
            res.DepartmnetName = (await _departmnetRepository.GetByKey(emp.DepartmentId)).Name;
            result.Add(res);
        }
        return result;
    }
}