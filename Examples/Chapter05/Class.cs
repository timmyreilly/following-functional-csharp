using Examples.Chapter3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaYumba;
using LaYumba.Functional;
using System.Diagnostics;

namespace Examples.Chapter05
{
    using static F;

    public static class Chapter5Testing
    {
        static decimal AverageEarnings(List<Person> population)
            => population
            .OrderByDescending(p => p.Earnings)
            .Take(population.Count / 4)
            .Select(p => p.Earnings)
            .Average();

        public static decimal AverageEarnings(this IEnumerable<Person> population)
            => population.Average(p => p.Earnings);

        public static IEnumerable<Person> RichestQuartile(this List<Person> pop)
            => pop.OrderByDescending(p => p.Earnings)
            .Take(pop.Count / 4);

        [TestCase(ExpectedResult = 75000)]
        public static decimal AverageEarningsOfRichestQuartile()
        {
            var population = Range(1, 8)
                .Select(i => new Person { Earnings = i * 10000 })
                .ToList();

            return AverageEarnings(population);
            // return PopulationStatistics.AverageEarningsOfRichestQuartile(population);
        }

        [TestCase(ExpectedResult = 75000)]
        public static decimal AverageEarningBrokenDown() => SamplePop.RichestQuartile().AverageEarnings();

        public static List<Person> SamplePop => Range(1, 8).Select(i => new Person { Earnings = i * 10000 }).ToList();



    }

}
