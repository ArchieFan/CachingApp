using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class EmployeesDataAccess
    {
        private readonly IMemoryCache _memoryCache;

        public EmployeesDataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new();
            employees.Add(new Employee { Id = 1, FirstName = "FN1", LastName = "LN1" });
            employees.Add(new Employee { Id = 2, FirstName = "FN2", LastName = "LN2" });
            employees.Add(new Employee { Id = 3, FirstName = "FN3", LastName = "LN3" });
            Thread.Sleep(3000);
            return employees;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = new();
            employees.Add(new Employee { Id = 1, FirstName = "FN1", LastName = "LN1" });
            employees.Add(new Employee { Id = 2, FirstName = "FN2", LastName = "LN2" });
            employees.Add(new Employee { Id = 3, FirstName = "FN3", LastName = "LN3" });
            await Task.Delay(3000);
            return employees;
        }

        public async Task<List<Employee>> GetEmployeesCache()
        {
            List<Employee> employees;
            employees = _memoryCache.Get<List<Employee>>("employees");
            if (employees is null)
            {
                employees =  new();
                employees.Add(new Employee { Id = 1, FirstName = "FN1", LastName = "LN1" });
                employees.Add(new Employee { Id = 2, FirstName = "FN2", LastName = "LN2" });
                employees.Add(new Employee { Id = 3, FirstName = "FN3", LastName = "LN3" });
                await Task.Delay(3000);
                _memoryCache.Set("employees", employees, TimeSpan.FromMinutes(1));
            }
            return employees;
        }
    }
}
