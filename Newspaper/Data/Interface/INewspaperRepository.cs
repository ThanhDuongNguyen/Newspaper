using Newspaper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Newspaper.Data.Interface
{
    public interface INewspaperRepository
    {
        Task<IEnumerable<Newspaper>> GetEmployeesAsync(Guid companyId, EmployeeParameters
employeeParameters, bool trackChanges);

    }
}
