using System;
using System.Collections.Generic;
using System.Linq;
using LaYumba.Functional;

namespace Exercises.Chapter4
{
    static class Exercises
    {
        // 1 Implement Map for ISet<T> and IDictionary<K, T>. (Tip: start by writing down
        // the signature in arrow notation.)

        // Map : ISet<T> -> (T -> R) -> ISet<R>
        static ISet<R> Map<T, R>(this ISet<T> ts, Func<T, R> f)
        {
            var rs = new HashSet<R>();
            foreach (var t in ts)
                rs.Add(f(t));
            return rs;
        }

        // Map : IDictionary<K, T> -> (T -> R) -> IDictionary<K, R>

        static IDictionary<K, R> Map<K, T, R>(this IDictionary<K, T> dict, Func<T, R> f)
        {
            var rs = new Dictionary<K, R>();
            foreach (var pair in dict)
                rs[pair.Key] = f(pair.Value);
            return rs; 
        }

        // 2 Implement Map for Option and IEnumerable in terms of Bind and Return.

        // 3 Use Bind and an Option-returning Lookup function (such as the one we defined
        // in chapter 3) to implement GetWorkPermit, shown below. 

        // Then enrich the implementation so that `GetWorkPermit`
        // returns `None` if the work permit has expired.

        static Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId)
        {
            throw new NotImplementedException();
        }

        // 4 Use Bind to implement AverageYearsWorkedAtTheCompany, shown below (only
        // employees who have left should be included).

        static double AverageYearsWorkedAtTheCompany(List<Employee> employees)
        {
            // your implementation here...
            throw new NotImplementedException();
        }
    }

    public struct WorkPermit
    {
        public string Number { get; set; }
        public DateTime Expiry { get; set; }
    }

    public class Employee
    {
        public string Id { get; set; }
        public Option<WorkPermit> WorkPermit { get; set; }

        public DateTime JoinedOn { get; }
        public Option<DateTime> LeftOn { get; }
    }
}