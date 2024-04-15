using GraduateProjectAPI.DTO.Employee;

namespace GraduateProjectAPI.Service.Interface
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetListEmployee();
    }
}
