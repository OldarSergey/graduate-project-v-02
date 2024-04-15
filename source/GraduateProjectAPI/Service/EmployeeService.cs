using GraduateProjectAPI.DTO.Employee;
using GraduateProjectAPI.Persistence;
using GraduateProjectAPI.Service.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GraduateProjectAPI.Service;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;
    private readonly string _connectionString;

    public EmployeeService(IConfiguration configuration, ApplicationDbContext context)
    {
        _connectionString = configuration.GetConnectionString("AtomexDbConnection");
        _context = context;
    }


    public async Task<List<EmployeeDto>> GetListEmployee()
    {
        var employees = new List<EmployeeDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("GetPeopleData", connection))
            {
                command.CommandType = CommandType.StoredProcedure;


                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    int rowCount = 0;

                    while (reader.Read() && rowCount < 20) // Читаем только первые 20 строк
                    {
                        var employee = new EmployeeDto
                        {
                            Id = reader.GetInt32("ManKeyA"),
                            FullName = reader.GetString("ManNameA"),
                            Duty = reader.GetString("Duty"),
                            Department = reader.GetString("Dep"),
                            Phone = reader.GetString("Phone")
                        };

                        employees.Add(employee);
                        rowCount++; // Увеличиваем счетчик прочитанных строк

                        if (rowCount >= 20) // Если прочитано 20 строк, прекращаем чтение
                        {
                            break;
                        }
                    }
                }

            }
        }
        return employees;
    }
}