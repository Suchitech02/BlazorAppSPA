using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAppSPA.DTO;
using BlazorAppSPA.Models;
using BlazorAppSPA.Repository;
using System.Data.SqlClient;
using BlazorAppSPA.Configuration;
using Dapper;
using System.Data;
using System;

namespace BlazorAppSPA.DAL
{
    public class EmployeeService : IEmployeeService
    {
        SqlConnectionConfiguration Configuration;
        public EmployeeService(SqlConnectionConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            // New concept where dynamic parameter has been used
            var parameters = new DynamicParameters();
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Department", employee.Department, DbType.String);
            parameters.Add("Designation", employee.Designation, DbType.String);
            parameters.Add("Company", employee.Company, DbType.String);
            parameters.Add("CityId", employee.CityId, DbType.String);
            // parameters.Add("CityName", employee.Name, DbType.String); will be used in UI
            using(var con = new SqlConnection(Configuration.value))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    try
                    {
                        // we can do same operation in  Ado.net by using execute nonquery
                        await con.ExecuteAsync("Add_Employee",parameters,commandType:CommandType.StoredProcedure);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                

                }
                return true;
            }

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