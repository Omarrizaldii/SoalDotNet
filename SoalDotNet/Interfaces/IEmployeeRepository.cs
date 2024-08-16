using SoalDotNet.Model;

namespace SoalDotNet.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetAll();
    }
}