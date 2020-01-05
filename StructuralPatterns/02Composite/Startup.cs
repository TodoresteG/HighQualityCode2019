namespace Composite
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            IEmployee peter =
                new Employee { EmployeeID = 1, Name = "peter", Rating = 3 };

            IEmployee george =
                new Employee { EmployeeID = 2, Name = "george", Rating = 4 };

            IEmployee john =
                new Employee { EmployeeID = 3, Name = "john", Rating = 5 };

            IEmployee adam =
                new Employee { EmployeeID = 4, Name = "adam", Rating = 3 };

            IEmployee martin =
                new Employee { EmployeeID = 5, Name = "martin", Rating = 4 };

            IEmployee jenny =
                new Employee { EmployeeID = 6, Name = "jenny", Rating = 5 };

            Supervisor michael =
                new Supervisor { EmployeeID = 7, Name = "michael", Rating = 3 };

            Supervisor justin =
                new Supervisor { EmployeeID = 8, Name = "justin", Rating = 3 };

            michael.AddSubordinate(peter);
            michael.AddSubordinate(george);
            michael.AddSubordinate(john);

            justin.AddSubordinate(adam);
            justin.AddSubordinate(martin);
            justin.AddSubordinate(jenny);

            Console.WriteLine($"{Environment.NewLine}--- Employee can see their Performance " +
                              "Summary --------");
            peter.PerformanceSummary();

            Console.WriteLine($"{Environment.NewLine}--- Supervisor can also see their " +
                              "subordinates performance summary-----");
            michael.PerformanceSummary();

            Console.WriteLine($"{Environment.NewLine}Subordinate Performance Record:");
            
            foreach (IEmployee employee in michael.ListSubordinates)
            {
                employee.PerformanceSummary();
            }
        }
    }
}