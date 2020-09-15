using EntityFramework_Classic_Count_example.DALs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework_Classic_Count_example
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new DataAccessService(new TestContext());

            var workingPureEFCore = service.GetAllElements()
                .Where(p => (p.Name == "test"))
                .Where(p => p.Active)
                .Where(p => new List<int>() { 1, 2, 3, 4 }.Contains(p.Id))
                .GroupBy(p => new { p.Id, p.Name })
                .Select(p => new { p.Key.Id, p.Key.Name, Counts = p.Count() })
                .ToList();

            var notWorkingZEFClassic = service.GetAllElements().Execute<object>(
                "Where(p => (p.Name== \"test\"))" +
                ".Where(p => p.Active)" +
                ".Where(p => new List<int>() { 1, 2, 3, 4 }.Contains(p.Id))" +
                ".GroupBy(p => new { p.Id, p.Name})" +
                ".Select(p => new { p.Key.Id, p.Key.Name, Counts =  p.Count() })" +
                ".ToList()");

            Console.WriteLine("Hello World!");
        }
    }
}
