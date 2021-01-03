using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAppSPA.DTO;
using BlazorAppSPA.Models;
using BlazorAppSPA.Repository;
using System.Data.SqlClient;

namespace BlazorAppSPA.DAL
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {
            
        }
        public Task<bool> CreateEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteEmployee(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditEmployee(int id, EmployeeModel employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public Task<EmployeeModel> SingleEmployee(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}