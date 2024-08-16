using SoalDotNet.Interfaces;
using SoalDotNet.Model;

namespace SoalDotNet.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();
        private int id = 1000;

        public EmployeeRepository()
        {
            _employees.Add(new Employee
            {
                EmployeeID = id++,
                FullName = "Adit",
                BirthDate = new DateTime(1954, 08, 17)
            });
            _employees.Add(new Employee
            {
                EmployeeID = id++,
                FullName = "Anton",
                BirthDate = new DateTime(1954, 08, 18)
            });
            _employees.Add(new Employee
            {
                EmployeeID = id++,
                FullName = "Amir",
                BirthDate = new DateTime(1954, 08, 19)
            });
        }

        // function for add
        public void AddEmployee(Employee employee)
        {
            employee.EmployeeID = id++;
            _employees.Add(employee);
        }

        // function for delete
        public void DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(o => o.EmployeeID == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            else
            {
                Console.WriteLine($"Employee with Id: {id} not found");
            }
        }

        // function for get list
        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }
    }
}