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
            var parameters = new DynamicParameters(); // Native API call thats why its faster than EF
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

        public async Task<bool> DeleteEmployee(int id)
        {
             var parameters = new DynamicParameters(); // Native API call thats why its faster than EF
            parameters.Add("Id", id, DbType.Int32); // DvType is binding
            // parameters.Add("CityName", employee.Name, DbType.String); will be used in UI
            using(var con = new SqlConnection(Configuration.value))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    try
                    {
                        // we can do same operation in  Ado.net by using execute nonquery
                        await con.ExecuteAsync("Delete_Employee",parameters,commandType:CommandType.StoredProcedure);
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

        public async Task<bool> EditEmployee(int id, EmployeeModel employee)
        {
            var parameters = new DynamicParameters(); // Native API call thats why its faster than EF
            parameters.Add("Id", id, DbType.Int32); // DvType is binding
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
                        await con.ExecuteAsync("Update_Employee",parameters,commandType:CommandType.StoredProcedure);
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

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            IEnumerable<EmployeeModel> employees = null;
             using(var con = new SqlConnection(Configuration.value))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    try
                    {
                        // QueryAsync has been used for Retrieval the data 
                        employees = await con.QueryAsync<EmployeeModel>("Get_AllEmployees", commandType: CommandType.StoredProcedure);
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
                return employees;
            }
        }

        public async Task<EmployeeModel> SingleEmployee(int id)
        {
            var parameters = new DynamicParameters(); // Native API call thats why its faster than EF
            parameters.Add("Id", id, DbType.Int32);
            EmployeeModel employee = new EmployeeModel();
            using (var con = new SqlConnection(Configuration.value))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    try
                    {
                        employee= await con.QueryFirstAsync<EmployeeModel>(
                            "Get_SingleEmployee",parameters, commandType: CommandType.StoredProcedure); // QueryFirstAsync is used to fetch single record
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }

            }
            return employee;
        }
    }
}
    