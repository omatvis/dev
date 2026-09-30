using System;

namespace Composition
{
    /*
     * Real-world task: Organization & Payroll System
     *
     * The company is structured hierarchically:
     * - The company has multiple Departments (e.g., Engineering, HR).
     * - Departments can contain individual Employees (e.g., a Senior Developer).
     * - Departments can also contain nested sub-departments (e.g., Engineering contains the DevOps team).
     *
     * Objective:
     * Provide a uniform way to calculate the total budget/payroll for any part of the
     * organization. Client code should be able to call GetBudget() on a single employee,
     * a team, a department, or the entire corporation without distinguishing between them.
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            var company = new Department("TechCorp")
                 .AddComponent(new Employee("Alice", 90000))
                 .AddComponent(new Employee("Bob", 10000))
                 .AddComponent(new Department("Engineering"))
                     .AddComponent(new Employee("Charlie", 120000))
                 .AddComponent(new Department("HR")
                     .AddComponent(new Employee("Diana", 80000))
                     .AddComponent(new Employee("Eve", 75000)));
            Console.WriteLine(company.GetBudget());

        }
    }

    public interface IOrganizationComponent
    {
        decimal GetBudget();
    }

    public class Employee: IOrganizationComponent
    {
        public string Name { get; }
        public decimal Salary { get; }
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
        public decimal GetBudget() => Salary;
    }

    public class Department: IOrganizationComponent
    {   
        private readonly List<IOrganizationComponent> _components = new List<IOrganizationComponent>();
        public string Name { get; }
        public Department(string name)
        {
            Name = name;
        }
        public Department AddComponent(IOrganizationComponent component)
        {
            _components.Add(component);
            return this;
        }
        public decimal GetBudget()
        {
            decimal total = 0;
            foreach (var component in _components)
            {
                total += component.GetBudget();
            }
            return total;
        }
    }
}
