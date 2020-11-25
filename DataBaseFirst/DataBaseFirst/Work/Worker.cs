using DataBaseFirst.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst.Work
{
    class Worker
    {
        public void Run()
        {
            List<employee> queryResults;
            int resultCount;
            using (var db = new EmployeesEntities())
            {
                var query = db.employees.Include("dependents").Where(e => e.salary > 10000);
                Console.WriteLine(query.ToString());
                queryResults = query.ToList();
                resultCount = query.Count();
                Console.WriteLine($"Total count = {resultCount}");
            }

            foreach (var emp in queryResults)
            {
                Console.WriteLine($"{emp.first_name} {emp.last_name}");
                foreach (var dep in emp.dependents)
                {
                    Console.WriteLine($"    {dep.first_name} {dep.last_name}");
                }
            }
        }
    }
}
