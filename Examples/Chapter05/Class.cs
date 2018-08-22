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

    public class Chapter5Testing
    {
        [TestCase(ExpectedResult = 75000)]
        public decimal AverageEarningsOfRichestQuartile()
        {
            var population = Range(1, 8)
                .Select(i => new Person { Earnings = i * 10000 })
                .ToList();

            return PopulationStatistics.AverageEarningsOfRichestQuartile(population);
        }

    }

}
