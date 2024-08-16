using SoalDotNet.Interfaces;
using SoalDotNet.Model;
using SoalDotNet.Repository;

namespace SoalDotNet
{
    public static class Program
    {
        public static IEmployeeRepository _employeeRepository = new EmployeeRepository();

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----------------- Menu -----------------");
                Console.WriteLine("Choose an option");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddEmployee();
                        break;

                    case "2":
                        ViewEmployees();
                        break;

                    case "3":
                        DeleteEmployee();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.WriteLine("---");
                Console.WriteLine();
                Console.WriteLine("Hit any key to proceed.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void ViewEmployees()
        {
            Console.WriteLine("List of Employees:");

            var employees = _employeeRepository.GetAll();

            if (!employees.Any())
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeID}, FullName: {employee.FullName}, BirthDate: {employee.BirthDate}");
            }
        }

        private static void AddEmployee()
        {
            Console.WriteLine("Create a new Employee");
            Employee employee = new();

            Console.WriteLine("Enter FullName: ");
            var fullName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fullName))
            {
                employee.FullName = fullName;
            }
            else
            {
                Console.WriteLine("FullName is required");
                return;
            }

            Console.Write("Enter BirthDate (dd-MMM-yy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
            {
                employee.BirthDate = birthDate;
            }
            else
            {
                Console.WriteLine("Invalid date format.");
                return;
            }
            _employeeRepository.AddEmployee(employee);
            Console.WriteLine("Succesfully added employee");
        }

        private static void DeleteEmployee()
        {
            Console.Write("Enter the ID of the employee you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _employeeRepository.DeleteEmployee(id);
                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID input.");
            }
        }
    }
}