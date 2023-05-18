using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.AppCode.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Dpartment>> GetDepartment();
        Task<Response> AddAsync(Employee req);
        Task<Response> Delete(int Id);
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int Id);
        Task<GetNewsDB> GetNews();
        Task<Response> AddNews(GetNewsDB req);
    }
}
