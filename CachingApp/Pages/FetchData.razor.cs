using Microsoft.AspNetCore.Components;
using DataAccessLibrary;

namespace CachingApp.Pages
{
    public partial class FetchData
    {
        [Inject]
        private EmployeesDataAccess? EmployeesService { get; set; }

        List<Employee>? employees;

        protected override async Task OnInitializedAsync()
        {
            //employees = EmployeesService.GetEmployees();
            //employees = await EmployeesService.GetEmployeesAsync();
            employees = await EmployeesService.GetEmployeesCache();
        }
    }
}
