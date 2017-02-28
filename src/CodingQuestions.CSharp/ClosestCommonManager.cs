using System;
using System.Collections.Generic;

namespace CodingQuestions.CSharp
{
    /// <summary>
    ///       Bill --> CEO
    ///      /       |    \
    ///     DOM    SAMIR  MICHAEL
    ///    /  \   \
    ///   Peter Bob Porter
    ///   /    \
    ///  Milton Nina
    /// </summary>
    public class ClosestCommonManager
    {
        public void Run()
        {
            // ceo
            var bill = new Employee { Name = "Bill" };
            // 2nd
            var dom = new Employee { Name = "Dom", Manager = bill };
            var samir = new Employee { Name = "Samir", Manager = bill };
            var micheal = new Employee { Name = "Micheal", Manager = bill };
            // 3rd
            var peter = new Employee { Name = "Peter", Manager = dom };
            var bob = new Employee { Name = "Bob", Manager = dom };
            var porter = new Employee { Name = "Porter", Manager = dom };
            // 4th
            var milton = new Employee { Name = "Milton", Manager = peter };
            var nina = new Employee { Name = "Nina", Manager = peter };

            bill.Reports.AddRange(new[] { dom, samir, micheal });
            dom.Reports.AddRange(new[] { peter, bob, porter });
            peter.Reports.AddRange(new[] { milton, nina });
        }

        /// <summary>
        /// O(log(n)) time complexity. O(1) memory
        /// </summary>
        public static Employee Method1UsingParentNode(Employee employee1, Employee employee2)
        {
            var e1 = employee1;
            var e2 = employee2;

            // find the number of nodes to the root for e1 and e2
            int h1 = 0;
            int h2 = 0;
            while (e1 != null || e2 != null)
            {
                if (e1 != null)
                {
                    e1 = e1.Manager;
                    h1++;
                }
                if (e2 != null)
                {
                    e2 = e2.Manager;
                    h2++;
                }
            }

            if (h1 > h2)
            {
                e1 = employee1;
                e2 = employee2;
            }
            else
            {
                e1 = employee2;
                e2 = employee1;
            }

            int diff = Math.Abs(h1 - h2);
            while (diff > 0)
            {
                e1 = e1.Manager;
                diff--;
            }

            while (e1 != e2)
            {
                e1 = e1.Manager;
                e2 = e2.Manager;
            }

            return e1;
        }

        /// <summary>
        /// O(log(n)) time complexity. O(log(n)) memory
        /// </summary>
        public static Employee Method2UsingParentNode(Employee employee1, Employee employee2)
        {
            var ls1 = new Stack<Employee>();
            var ls2 = new Stack<Employee>();
            while (employee1 != null || employee2 != null)
            {
                if (employee1 != null)
                {
                    ls1.Push(employee1);
                    employee1 = employee1.Manager;
                }
                if (employee2 != null)
                {
                    ls2.Push(employee2);
                    employee2 = employee2.Manager;
                }
            }

            Employee result = null;
            while (ls1.Count > 0 && ls2.Count > 0)
            {
                if (ls1.Peek() != ls2.Peek())
                {
                    break;
                }

                result = ls1.Pop();
                ls2.Pop();
            }

            return result;
        }


        public class Employee
        {
            public string Name { get; set; }

            public Employee Manager { get; set; }

            public List<Employee> Reports { get; set; }

            public Employee()
            {
                this.Reports = new List<Employee>();
            }
        }
    }
}
